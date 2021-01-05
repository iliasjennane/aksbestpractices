az account set -s "7fbd5782-682d-442e-a6d3-970227de186d"

$azrg = "iliasj-aks-bestpractices-rg"
$azregion = "eastus"
$azacr = "iliasjdemoscr"
$azaks = "iliasjdemosaks"
az group create --name $azrg --location $azregion

az acr create -n $azacr -g $azrg --sku Standard

az aks create --name $azaks --location $azregion   --attach-acr  $azacr  --resource-group $azrg 
az aks get-credentials --name $azaks --resource-group $azrg
