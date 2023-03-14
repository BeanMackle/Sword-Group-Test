# Sword Group Test

Completed to the brief spec - I didn't want to spend too long on this as I feel that would defeat the point - though as you can see from commits, I did come back a couple times to sort out little things like formatting.

Things I would improve:
* The reoccuring 'Stopping process.........' - I would make this a constant
* Error handling - I think it's somewhat reasonable to assume an app like this may be directly used by a non technical user, clearer error messages would be nice e.g. use value 'true' for case sensitivity.
* Ordering of the dictionary - produces inconsistent output if a lot of characters have the same count, while technically not wrong I think it would make sense if alphabetical order was also taken into account.
* use of an actual logger
* Regex improvement for 'non-valid' character removal
