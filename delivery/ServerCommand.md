# class diagram
- ตั้งค่า Visual code Settings
    - Plantuml: Server = https://plantuml.com/plantuml

## Server Command
มี base class ใหญ่คือ ServerCommand แตกออกเป็น 3 สายตามโครงสร้าง
- ProctorCommand<T>
    - ใช้ ProctorCommandParameter เป็น parameter
- TxCommand<T>
    - ใช้ TxCommandParameter เป็น parameter
- WalletCommand<T>
    - ใช้ WalletCommandParameter เป็น parameter

```plantuml
@startuml

ServerCommand <|-- "ServerCommand<T>"
"ServerCommand<T>" <|-- "ProctorCommand<T>" 
"ServerCommand<T>" <|-- "TxCommand<T>"
"ServerCommand<T>" <|-- "WalletCommand<T>"

"ProctorCommand<T>" <|-- BizHomeVisitCommand
"TxCommand<T>" <|-- CartCreateCommand
"WalletCommand<T>" <|-- EscrowCreateCommand

abstract class ServerCommand {
    Action
    // JsonElement RawParam
}
abstract class "ServerCommand<T>" {
    Parameter: T
}
abstract class "ProctorCommand<T>" {
    // where T : ProctorCommandParameter
 }
class BizHomeVisitCommand {
    Parameter: BizHomeVisitParameter
}
abstract class "TxCommand<T>" {
    // where T : TxCommandParameter
}
class CartCreateCommand {
    Parameter: CartCreateParameter
}
abstract class "WalletCommand<T>" {
    // where T : WalletCommandParameter
}
class EscrowCreateCommand {
    Parameter: EscrowCreateParameter
}

@enduml
```
### ตัวอย่าง Command ต่างๆ
<details>
<summary>ProctorCommand</summary>
<pre>
- BizHomeVisitCommand
- ProductVisitCommand  
- ProductActionCommand
- DeliveryMethodChangeCommand
- LocationChangeCommand
- OrderCheckoutCommand
- ReminderCreateCommand
- ReminderUpdateCommand
- EscrowReleaseCommand
- ReminderEndCommand
- . . .
</pre>
</details>
<details>
<summary>TxCommand</summary>
<pre>
- CartCreateCommand
- OrderCreateCommand
- ProductAddCommand
- DeliveryMethodChangeCommand
- LocationChangeCommand
- OrderCheckoutCommand
- OrderCancelCommand
- PromptpayDepositStartCommand
- PromptpayDepositEndCommand
- PromptpayWithdrawStartCommand
- . . .
</pre>
</details>
<details>
<summary>WalletCommand</summary>
<pre>
- EscrowCreateCommand
- EscrowCreateCommand
- TransferCommand
- EscrowCancelCommand
- WalletDepositCommand
- WalletWithdrawCommand
- WalletPaymentCommand
- DevCreateCommand
- BACreateCommand
- BADeliveryCreateCommand
- BudgetCreateCommand
- . . .
</pre>
</details>

## Proctor Command Parameter
Parameter ของ Proctor จะมีเรื่อง grant และแบ่งเป็น parameter จากฝั่ง mana app และ 3rd party

```plantuml
@startuml

ProctorCommandParameter <|-- ProctorManaCommandParameter
ProctorCommandParameter <|-- Proctor3rdCommandParameter

abstract class ProctorCommandParameter {
    // Owner
    // Grant
    // Command
    // Proof
}
abstract class ProctorManaCommandParameter { }
abstract class Proctor3rdCommandParameter { }

@enduml
```
### Proctor Mana Command Parameter
parameter ฝั่ง mana app จะทำงานกับ endpoint เป็นหลัก

```plantuml
@startuml

ProctorManaCommandParameter <|-- BizHomeVisitParameter
ProctorManaCommandParameter <|-- ProductVisitParameter
ProctorManaCommandParameter <|-- ManaRequestBodyParameter
ManaRequestBodyParameter <|-- ProductActionParameter

abstract class ProctorManaCommandParameter {
    EndpointId **// nxxxyyy.1-22222~33333**
    State **// n/m => stateless or stateful**
    Module **// xxx**
    Operation **// yyy**
    Step **// 1**
    Id **// 22222**
    CorelationId **// 33333**
}
class ManaRequestBodyParameter {
    Location[] Locations
    FileAttachment[] Attachments
    JsonElement Body
}
class ProductActionParameter {
    Quantity
    Preferences
    Options
}

@enduml
```
### Mana Request Body Parameter (optional)
ManaRequestBodyParameter อาจจะ implement มาจาก abstract แต่ละเรื่อง

```plantuml
@startuml

mana.MContentParameter <|-- mana.ManaRequestBodyParameter
mana.GspParameter <|-- mana.ManaRequestBodyParameter
mana.UploadParameter <|-- mana.ManaRequestBodyParameter

abstract class mana.MContentParameter {
    JsonElement Body
}
abstract class mana.GspParameter {
    Location[] Locations
    // Address
    // Latitude
    // Longitude
    // PhoneNumber
    // Remark
}
abstract class mana.UploadParameter {
    FileAttachment[] Attachments
    // Id
    // ContentType
    // Url
}

@enduml
```

### Proctor 3rd Command Parameter
parameter ฝั่ง 3rd party จะทำงานกับ id เป็นหลัก และระบุว่า service / biz ไหน

```plantuml
@startuml
Proctor3rdCommandParameter <|-- GetUploadSasParameter

abstract class Proctor3rdCommandParameter {
    Id
    ServiceId
    BizAccountId
}
class GetUploadSasParameter {
    Type
}

@enduml
```

## Tx Command Parameter
ทำงานกับ id ที่มาจาก endpoint เป็นหลัก หรืออาจจะมีบาง command ที่ไม่ต้องมี id เพราะรู้จาก context อยู่แล้ว เช่น personalAccountId

```plantuml
@startuml

TxCommandParameter <|-- TxCommandIdParameter
TxCommandParameter <|-- CartCreateParameter
TxCommandIdParameter <|-- OrderCreateParameter

abstract class TxCommandParameter { }
abstract class TxCommandIdParameter
{
    Id
}

@enduml
```

## Wallet Command Parameter
ทำงานกับ id ของ wallet/escrow เป็นหลัก

```plantuml
@startuml

WalletCommandParameter <|-- EscrowCreateParameter
WalletCommandParameter <|-- ReleaseEscrowParameter

abstract class WalletCommandParameter {
    Id
}
class EscrowCreateParameter {
    In: []
    out: []
}

@enduml
```

# Models

```csharp
    abstract class ServerCommand
    {
        public string Action { get; set; }
        // JsonElement RawParam
    }

    abstract class ServerCommand<T> : ServerCommand
    {
        public T Parameter { get; set; }
    }

    abstract class ProctorCommand<T> : ServerCommand<T> where T : ProctorCommandParameter { }
    abstract class TxCommand<T> : ServerCommand<T> where T : TxCommandParameter { }
    abstract class WalletCommand<T> : ServerCommand<T> where T : WalletCommandParameter { }

    abstract class ServerCommandParameter
    {
        public string Owner { get; set; }
        public string Grant { get; set; }
        public string Command { get; set; }
        public string Proof { get; set; }
    }
    abstract class ProctorCommandParameter : ServerCommandParameter
    {
        public string EndpointId { get; set; }

        public string State { get; }
        public string Module { get; }
        public string Operation { get; }
        public string Step { get; }
        public string Id { get; }
        public string CorelationId { get; }
    }
    abstract class TxCommandParameter : ServerCommandParameter { }
    abstract class TxCommandIdParameter : TxCommandParameter
    {
        public string Id { get; set; }
    }
    abstract class WalletCommandParameter : ServerCommandParameter { }
    abstract class WalletCommandIdParameter : WalletCommandParameter
    {
        public string Id { get; set; }
    }

    class CartCreateCommand : TxCommand<CartCreateParameter> { }
    class CartCreateParameter : TxCommandParameter { }
```