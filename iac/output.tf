output "wallet_application_insights_instrumentation_key" {
  value = module.global.wallet_application_insights_instrumentation_key
}

output "wallet_cosmosdb_connectionstrings" {
  value = module.database.wallet_cosmosdb_connectionstrings
}

output "wallet_servicebus_connection_string" {
  value = module.bus.wallet_servicebus_connection_string
}
