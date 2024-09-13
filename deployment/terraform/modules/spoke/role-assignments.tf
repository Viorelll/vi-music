# Terraform user as keyvault admin
resource "azurerm_role_assignment" "terraform_keyvault_admin" {
  scope                = azurerm_key_vault.this.id
  role_definition_name = "Key Vault Administrator"
  principal_id         = data.azurerm_client_config.current.object_id
}

# Terraform user as keyvault reader
resource "azurerm_role_assignment" "terraform_keyvault_user" {
  scope                = azurerm_key_vault.this.id
  role_definition_name = "Key Vault Reader"
  principal_id         = data.azurerm_client_config.current.object_id
}
