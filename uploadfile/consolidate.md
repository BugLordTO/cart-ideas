- scenarios
    - upload from client for mana
    - upload from client for 3rd
    - upload from partner api

- FileServiceApi
    - file upload api
        - [GET] file/upload[?count=1] >> get upload file sas
        - [POST] file/{fileName}/submit >> submit uploaded file
        - [GET] file/{fileName}/accesskey >> get read access key for private file
        - [POST] file/{fileName}/accesskey
            >> get read access key for private file of {dest_instance}
        - [PUT] file/{fileName}/accesskey/re >> regenerate file access key
        - [DELETE] file/{fileName}/delete >> delete file

        - [GET] somepath/{fileName} >> file content for public
        - [GET] somepath/{fileName}?{accessKey} >> file content for private

- FileServiceApi Description
    - get upload file sas (count) >> upload to temp storage
        - api: [GET] file/{instance}/upload[?count=1]
        - response
            - []
                - Url: blob url
                - FileName
                - FileId
                - Sas: blob sas
        - fileId >> path ใน blob เอาไว้ระบุตอนจะ upload
            - file/{instance}/{fileName}
        - fileName
            - GUID
    - submit upload (fileId) >> commit temp upload state, create snapshot
        - api: [POST] file/{instance}/{fileName}/submit
        - request
            - UploadFileName
            - ContentType
            - Instance?: public, private ?? temp >> submit แล้วจะย้ายไป instance ไหนต่อเลย
        - response
            - Url
            - AccessKey?
                - ทำยังไงให้ใช้ได้กับ 2 url ในช่วงที่กำลัง copy/move
                - สร้างเอง access key ที่ api
        - redis
            - FileId
            - BlobUrl
            - ContentType
            - AccessKey
            - Sas: read sas
        - hook
            - request
                - []
                    - fileId
                    - contentType
    - get [GET] read access key (fileId)
        - api: file/{instance}/{fileName}/accesskey
        - response
            - Url
            - AccessKey?
    - get read access key for private file of {dest_instance}
        - api: [POST] file/{dest_instance}/{fileName}/accesskey
        - request
            - Url
            - AccessKey
        - response
            - Url
            - AccessKey
    - regenerate file access key (fileId)
        - api: [PUT] file/{instance}/{fileName}/accesskey/re
    - delete instance (fileId)
        - api: [DELETE] file/{instance}/{fileName}/delete
    - file content (fileId) >> host url = apim
        - public: [GET] file/{instance}/{fileName}
        - private: [GET] file/{instance}/{fileName}?{accessKey}
    - real blob url
        - https://manauploaddev.blob.core.windows.net/temp/{instance}/{fileName}
        - https://manauploaddev.blob.core.windows.net/kyc/{instance}/{fileName}
        - https://manauploaddev.blob.core.windows.net/{instance}/{fileName}
        - https://manauploaddev.blob.core.windows.net/private/{fileName}
        - https://manauploaddev.blob.core.windows.net/public/{fileName}

- storage instance
    - temp
        - private
        - public
        - profile
            - employee
        - ba
        - kyc
        - product
            - product promotion
        - eslip
            - privilege
                - privilege promotion

- storage account >> 
    - temp
        - temp >> delete in 1 days
        - kyc >> delete in 30 days
    - ring
        - private >> require access key
        - public >> not require access key
        - ba
        - product
            - product promotion
        - eslip
            - privilege
                - privilege promotion
    - profile >> ตาม idp

#########################################################

- temp,kyc share ภายใน group dev,pre,prod
- mobile upload ของ mana flow เข้า temp ก่อน
- config container public/private
- accessKey
    - expire
    - หลายอัน? > limit

#########################################################

# file api
/- IFileService + IFileServiceFactory
/- mana api do not use IFileService

/- config yaml
- content type
- DB / redis
    - snapshot > save to db/redis?
    - manage api > account container folder > save/get from db
    - data api > account container folder > get from db
- access key
