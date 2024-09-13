resource "azurerm_static_web_app" "viqub_ui" {
  name                = "stapp-${var.application_name}-${var.environment_name}-${var.region_identifier}"
  resource_group_name = data.azurerm_resource_group.this.name
  location            = "westeurope" //data.azurerm_resource_group.this.location
}
