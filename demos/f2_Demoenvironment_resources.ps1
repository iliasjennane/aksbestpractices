az group create --name $azrg --location $azregion --tags Team=MSFT Environment=DevTest

az acr create -n $azacr -g $azrg --sku Standard
az acr login --name $azacr

az aks create --name $azaks --location $azregion   --attach-acr  $azacr  --resource-group $azrg --node-resource-group "$azrg-MC"
az aks get-credentials --name $azaks --resource-group $azrg
