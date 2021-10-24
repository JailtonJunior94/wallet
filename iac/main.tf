terraform {
  backend "azurerm" {
    resource_group_name  = "terraform-rg"
    storage_account_name = "storageterraformjj"
    container_name       = "partner-infra"
    key                  = "terraform.tfstate"
  }
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "=2.71.0"
    }
  }
}

provider "azurerm" {
  features {}
}

module "global" {
  source   = "./modules/global"
  location = var.location
}

module "database" {
  source              = "./modules/database"
  location            = var.location
  resource_group_name = module.global.wallet_resource_group_name
}

module "bus" {
  source              = "./modules/bus"
  location            = var.location
  resource_group_name = module.global.wallet_resource_group_name
}
