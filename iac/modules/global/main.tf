resource "azurerm_resource_group" "wallet_rg" {
  name     = "wallet-rg"
  location = var.location
}

resource "azurerm_application_insights" "wallet_application_insights" {
  name                = "wallet-insights"
  resource_group_name = azurerm_resource_group.wallet_rg.name
  location            = var.location
  application_type    = "web"
}
