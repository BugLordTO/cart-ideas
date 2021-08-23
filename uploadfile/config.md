# url route change
https://kycfileapi-dev.azurewebsites.net/data/{account}/{container}/{folder}/{file}
https://fileapi-dev.azurewebsites.net/{instance}/data/{account}/{container}/{folder}/{file}

# instance
https://fileapi-dev.azurewebsites.net/temp/data/{account}/{container}/{folder}/9dcfb67a-0c53-4a53-8a62-9aa39586be60
https://fileapi-dev.azurewebsites.net/temp/manage/{account}/{container}/{folder}/9dcfb67a-0c53-4a53-8a62-9aa39586be60

https://fileapi-dev.azurewebsites.net/profile/data/{account}/{userid}/image/9dcfb67a-0c53-4a53-8a62-9aa39586be60
https://fileapi-dev.azurewebsites.net/profile/manage/{account}/{userid}/image/9dcfb67a-0c53-4a53-8a62-9aa39586be60
https://fileapi-dev.azurewebsites.net/bizaccount/data/{account}/{baid}/image/9dcfb67a-0c53-4a53-8a62-9aa39586be60
https://fileapi-dev.azurewebsites.net/bizaccount/manage/{account}/{baid}/image/9dcfb67a-0c53-4a53-8a62-9aa39586be60

https://fileapi-dev.azurewebsites.net/kyctemp/data/{account}/upload/basic/9dcfb67a-0c53-4a53-8a62-9aa39586be60
https://fileapi-dev.azurewebsites.net/kyctemp/manage/{account}/upload/basic/9dcfb67a-0c53-4a53-8a62-9aa39586be60
https://fileapi-dev.azurewebsites.net/kyc/data/{account}/{userid}/basic/9dcfb67a-0c53-4a53-8a62-9aa39586be60
https://fileapi-dev.azurewebsites.net/kyc/manage/{account}/{userid}/basic/9dcfb67a-0c53-4a53-8a62-9aa39586be60

# configuration
```c#
class FileConfigOptions {
    IDictionary<string, StorageAccountConfigOptions> Configs { get; set; }
}
class StorageAccountConfigOptions {
    public string HostUrl { get; set; }
    public string ConnectionString { get; set; }
}
```

# configuration example
FileService
```json
{ "Configs":[
    { "temp":
        {
            "ConnectionString":"DefaultEndpointsProtocol=https;AccountName=manauploaddev",
            "HostUrl":"manauploaddev.blob.core.windows.net"
        }
    },
    { "profile":
        {
            "ConnectionString":"DefaultEndpointsProtocol=https;AccountName=manauserdev",
            "HostUrl":"manauserdev.blob.core.windows.net"
        }
    },
    { "bizaccount":
        {
            "ConnectionString":"DefaultEndpointsProtocol=https;AccountName=manaringdev",
            "HostUrl":"manaringdev.blob.core.windows.net"
        }
    },
    { "kyctemp":
        {
            "ConnectionString":"DefaultEndpointsProtocol=https;AccountName=manauploaddev",
            "HostUrl":"manauploaddev.blob.core.windows.net"
        }
    },
    { "kyc":
        {
            "ConnectionString":"DefaultEndpointsProtocol=https;AccountName=manauserdev",
            "HostUrl":"manauserdev.blob.core.windows.net"
        }
    }]
}
```