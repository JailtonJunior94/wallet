output "cosmosdb_connectionstrings" {
  value = nonsensitive(azurerm_cosmosdb_account.wallet_account.connection_strings)
}
