output "wallet_servicebus_connection_string" {
  value = nonsensitive(azurerm_servicebus_namespace.wallet_servicebus_namespace.default_primary_connection_string)
}
