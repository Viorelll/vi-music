locals {
  ci_cd_username = "ci_cd_user"
}

resource "azurerm_postgresql_flexible_server" "server" {
  name                   = "sql-${var.application_name}-${var.environment_name}-${var.region_identifier}"
  resource_group_name    = data.azurerm_resource_group.this.name
  location               = data.azurerm_resource_group.this.location
  administrator_login    = var.sqldb_admin_username
  administrator_password = random_password.sqldb_admin_password.result
  version                = "16"
  sku_name               = var.sqldb_sku
  zone                   = "1"

  storage_mb   = 32768
  storage_tier = "P4"
}

resource "azurerm_postgresql_flexible_server_firewall_rule" "allow_azure_services" {
  name             = "AllowAzureTrustedServices"
  server_id        = azurerm_postgresql_flexible_server.server.id
  start_ip_address = "0.0.0.0"
  end_ip_address   = "0.0.0.0"
}

resource "azurerm_postgresql_flexible_server_database" "db" {
  name      = "sqldb-${var.application_name}-${var.environment_name}-${var.region_identifier}"
  server_id = azurerm_postgresql_flexible_server.server.id
  collation = "en_US.utf8"
  charset   = "utf8"

  # prevent the possibility of accidental data loss
  lifecycle {
    prevent_destroy = true
  }
}
