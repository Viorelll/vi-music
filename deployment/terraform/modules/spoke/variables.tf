variable "resource_group_name" {
  type = string
}

variable "application_name" {
  type = string
}

variable "environment_name" {
  type = string
}

variable "region_identifier" {
  type = string
}

variable "aspnetcore_environment" {
  type = string
}


variable "sqldb_admin_username" {
  type = string
}

variable "sqldb_sku" {
  type = string
}

variable "sqldb_zone_redundant" {
  type = string
}

variable "sqldb_auto_pause_delay_in_minutes" {
  type = number
}

variable "sqldb_min_capacity" {
  type = number
}

variable "app_config_keys" {
  type = list(object({
    key                 = string
    value               = optional(string)
    vault_key_reference = optional(string)
    content_type        = optional(string)
    type                = optional(string)
  }))
}
