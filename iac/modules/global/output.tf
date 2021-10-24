output "wallet_resource_group_name" {
  value = azurerm_resource_group.wallet_rg.name
}

output "wallet_application_insights_instrumentation_key" {
  value = azurerm_application_insights.wallet_application_insights.instrumentation_key
}
