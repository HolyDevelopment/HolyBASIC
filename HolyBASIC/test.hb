holy _default :      "Hello world!\n"
holy _valueone :     "Hello Jesus!"
holy _valuetwo :     "^ Agreed."

gprint(_default)

gprint("\nValues:\n")
gprint('\n', _valueone)
gprint('\n', _valuetwo)

gprint("\n\nType something!\n")
holy _input : ""
gread(_input)
gprint("Is this what you typed? (y/n): ", _input)
gprint("\n")

glisten()