resource "azurerm_cosmosdb_account" "wallet_account" {
  name                      = "wallet-account"
  location                  = var.location
  resource_group_name       = var.resource_group_name
  offer_type                = "Standard"
  kind                      = "GlobalDocumentDB"
  enable_automatic_failover = true
  enable_free_tier          = true

  geo_location {
    location          = var.location
    failover_priority = 0
  }

  consistency_policy {
    consistency_level       = "BoundedStaleness"
    max_interval_in_seconds = 400
    max_staleness_prefix    = 200000
  }
}

resource "azurerm_cosmosdb_sql_database" "wallet_database" {
  name                = "walletdb"
  resource_group_name = azurerm_cosmosdb_account.wallet_account.resource_group_name
  account_name        = azurerm_cosmosdb_account.wallet_account.name
  throughput          = 400
  depends_on = [
    azurerm_cosmosdb_account.wallet_account
  ]
}

resource "azurerm_cosmosdb_sql_container" "wallet_users" {
  name                = "users"
  resource_group_name = azurerm_cosmosdb_account.wallet_account.resource_group_name
  account_name        = azurerm_cosmosdb_account.wallet_account.name
  database_name       = azurerm_cosmosdb_sql_database.wallet_database.name
  partition_key_path  = "/id"
  depends_on = [
    azurerm_cosmosdb_sql_database.wallet_database
  ]
}

resource "azurerm_cosmosdb_sql_container" "wallet_transactions" {
  name                = "transactions"
  resource_group_name = azurerm_cosmosdb_account.wallet_account.resource_group_name
  account_name        = azurerm_cosmosdb_account.wallet_account.name
  database_name       = azurerm_cosmosdb_sql_database.wallet_database.name
  partition_key_path  = "/id"
  depends_on = [
    azurerm_cosmosdb_sql_database.wallet_database
  ]
}
