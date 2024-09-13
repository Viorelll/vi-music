resource "azurerm_service_plan" "plan" {
  name                = "plan-${var.application_name}-${var.environment_name}-${var.region_identifier}"
  resource_group_name = data.azurerm_resource_group.this.name
  location            = data.azurerm_resource_group.this.location
  os_type             = "Linux"
  sku_name            = "F1"
}

resource "azurerm_linux_web_app" "webapp" {
  name                = "webapp-${var.application_name}-${var.environment_name}-${var.region_identifier}"
  resource_group_name = data.azurerm_resource_group.this.name
  location            = data.azurerm_resource_group.this.location
  service_plan_id     = azurerm_service_plan.plan.id

  site_config {
    always_on = "false"

    application_stack {
      dotnet_version = "8.0"
    }
  }


  app_settings = {
    ConnectionStrings = "@Microsoft.KeyVault(VaultName=${azurerm_key_vault_secret.sqldb_admin_password.name};SecretName=sqldb_admin_password)"
  }
}
