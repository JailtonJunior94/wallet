resource "azurerm_servicebus_namespace" "wallet_servicebus_namespace" {
  name                = "sb-wallet"
  location            = var.location
  resource_group_name = var.resource_group_name
  sku                 = "Basic"
}

resource "azurerm_servicebus_queue" "transaction_queue" {
  name                  = "transaction-queue"
  resource_group_name   = var.resource_group_name
  namespace_name        = azurerm_servicebus_namespace.wallet_servicebus_namespace.name
  enable_partitioning   = true
  max_size_in_megabytes = 1024
  depends_on = [
    azurerm_servicebus_namespace.wallet_servicebus_namespace
  ]
}
