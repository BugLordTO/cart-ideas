# TheS.Mana.Shared ที่มีการใช้งานใน server

1. TheS.Mana.Shared.Models.**ClientResponse**
1. TheS.Mana.Shared.Models.**OperationWorkflow**
1. TheS.Mana.Shared.ActionCommands.**[xxxActionCommand*]**
1. TheS.Mana.Shared.ActionCommands.Parameters.**[xxxActionCommandParameter*]**
1. TheS.Mana.Shared.ConditionalExpressions.**[xxxLogic*]**
1. TheS.Mana.Shared.ConditionalExpressions.Parameters.**[xxxLogicParameter*]**

# TheS.DevXP ที่มีการ ref จาก TheS.Mana.Shared

1. TheS.DevXP.ProPractices.Remoting.**ClientRemotingMessage** [abstract]
1. TheS.DevXP.ProPractices.Remoting.**ClientTrigger** [class]
1. TheS.DevXP.ProPractices.Remoting.**ClientEvent** [class]
1. TheS.DevXP.ProPractices.Remoting.**ActionCommand** [class]
1. TheS.DevXP.ProPractices.Remoting.**IClientRemotingContext** [interface]
1. TheS.DevXP.ProPractices.Remoting.**IConditionalExpressionLogic** [interface]
1. TheS.DevXP.ProPractices.Remoting.**ILogicEvaluatorBuilder** [interface]
1. TheS.DevXP.ProPractices.Remoting.**ILogicEvaluatorBuilderUsingServiceProvider** [interface]
1. TheS.DevXP.ProPractices.Remoting.**IConditionalLogicEvaluator** [interface]
1. TheS.DevXP.ProPractices.Remoting.**IHaveCommandParams** [interface]
1. TheS.DevXP.ProPractices.Remoting.**ConditionalExpressionLogic** [abstract]
1. TheS.DevXP.ProPractices.Remoting.**CommandParametersContext** [class]
1. TheS.DevXP.ProPractices.Remoting.Commands.**ConditionalExpression** [class]
1. TheS.DevXP.ProPractices.Remoting.Messaging.**IRequestingHub** [interface]
1. TheS.DevXP.ProPractices.Remoting.Messaging.**IReq** [interface]
1. TheS.DevXP.XamForms.UiServices.**DisplayAlert** [class]
1. TheS.DevXP.XamForms.UiServices.**UiServiceContextBase** [abstract]
1. TheS.DevXP.XamForms.Mvvm.**NavigationPageBase** [class]
1. TheS.DevXP.XamForms.Mvvm.**ContentPageBase** [class]

# ref ที่เกี่ยวข้อง

![](out/mana-shared-models/ClientResponse.png)

```plantuml

@startuml ClientResponse

package Xamarin.Forms {
    class ContentPage
    class NavigationPage
    class Page
    class Element
}

package MediatR {
    interface IRequest
    interface IBaseRequest
}

package TheS.DevXP {
    package ProPractices {
        package Remoting {
            abstract ClientRemotingMessage
            class ClientTrigger
            class ClientEvent
            class ActionCommand
            interface IClientRemotingContext
            interface IConditionalExpressionLogic
            interface ILogicEvaluatorBuilder
            interface ILogicEvaluatorBuilderUsingServiceProvider
            interface IConditionalLogicEvaluator
            interface IHaveCommandParams
            abstract ConditionalExpressionLogic
            class CommandParametersContext
            package Commands {
                class ConditionalExpression
            }
        }
        package Messaging {
            interface IRequestingHub
            interface IReq
        }
        IReq *- IRequestingHub
    }
    Remoting -[hidden]--- Messaging
    package XamForms {
        package UiServices {
            class DisplayAlert
            abstract UiServiceContextBase
        }
        package Mvvm {
            class NavigationPageBase
            class ContentPageBase
        }
    }
}
ClientRemotingMessage *-- ClientTrigger
ClientRemotingMessage *-- ClientEvent
ClientRemotingMessage *-- ActionCommand
ClientEvent *-- ActionCommand
IHaveCommandParams --* CommandParametersContext

IConditionalExpressionLogic *-- ConditionalExpression
IConditionalExpressionLogic <|-- ConditionalExpressionLogic
ILogicEvaluatorBuilderUsingServiceProvider <|-- ConditionalExpressionLogic
ILogicEvaluatorBuilder <|-- ConditionalExpressionLogic
IConditionalLogicEvaluator <|-- ILogicEvaluatorBuilder

ContentPage <|-- ContentPageBase
NavigationPage <|-- NavigationPageBase
NavigationPageBase *-- UiServiceContextBase
Page --* NavigationPageBase
Element --* NavigationPageBase

package TheS.Mana.Shared {
    package Models {
        class ClientResponse
        class WorkflowTask
        package Contracts {
            class SomeContractModel
        }
        package Workflows {
            class OperationWorkflow
        }
        WorkflowTask -[hidden]- Workflows
        WorkflowTask -[hidden]- Contracts
    }
    package ActionCommands {
        class SomeActionCommand
        package Parameters {
            class SomeActionCommandParameter
        }
    }
    package ConditionalExpressions {
        class ConfirmDialogLogicEvaluator
        class SomeLogic
        class SomeEvaluator
        package cParameters {
            class SomeLogicParameter
        }
    }
    package Services {
        interface SomeService
    }
    package Facades {
        interface SomeFacade
    }
    interface IMobileDevice {
        NavigationPageBase RootPage
        ContentPageBase TempletePages
    }
    ActionCommands -[hidden]-- IMobileDevice
}

ClientRemotingMessage <|-- ClientResponse
IClientRemotingContext <|-- WorkflowTask
ActionCommand <|-- SomeActionCommand
SomeActionCommand *-- SomeActionCommandParameter
SomeEvaluator *--- SomeService
SomeEvaluator *--- SomeFacade
ConditionalExpressionLogic <|-- SomeLogic
SomeLogic *-- SomeLogicParameter
IConditionalLogicEvaluator <|-- SomeEvaluator
SomeEvaluator *-- SomeLogicParameter
CommandParametersContext --* SomeLogicParameter

IRequestingHub *-- ConfirmDialogLogicEvaluator
DisplayAlert *-- ConfirmDialogLogicEvaluator

IBaseRequest --- DisplayAlert
IRequest --- DisplayAlert

@enduml
```

# เพิ่มเติม
1. TheS.Mana.Shared มี TheS.Mana.Essentials แต่ไม่มีการใช้งาน