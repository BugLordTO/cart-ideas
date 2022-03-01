Plantuml: Server = https://plantuml.com/plantuml
# Promotion flow
- url in promotion
    - share link url
    - reward url
- sharing
    - on mana
    - off mana
- url scheme + catch NavigateOrRequesting
    - https
    - manashare
    - manavisit

```plantuml
@startuml
(*) --> "is mana app?"
if "" then
    -->[yes] "engine?"
    if "" then
        -->[webview] "manashare://share?from=user1&distributer=user2" #lightgreen
        --> "reward button => manavisit://reward" #lightblue
        --> (*)
    else
        -->[system browser???] "how ?? normal browser ??" #pink
        --> "support share?"
    endif
else
    -->[no] "platform?"
    if "" then
        -->[mobile] "support share?" 
        if "" then
            -->[support] "navigator.share({title: title,text: text,url: 'https://share?from=user1'});" #lightgreen
            --> "reward button => href='https://reward'\nopen mana web show detail and endpoint QR with applink" #lightblue
        else
            -->[not support] "hide share link button" #lightgreen
            --> "reward button => href='https://reward'\nopen mana web show detail and endpoint QR with applink"
        endif
    else
        -->[pc] "manual share social lib => https://share?from=user1" #lightgreen
        --> "show reward button???" #pink
        if "" then
            -->[show] "reward button => href='https://reward'\nopen mana web show detail and endpoint QR with applink"
            --> (*)
        else
            -->[hide] (*)
        endif
    endif
endif
@enduml
```
