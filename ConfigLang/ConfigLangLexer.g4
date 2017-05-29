lexer grammar ConfigLangLexer;

WS
	:	[ \t] -> channel(HIDDEN)
	;

NewLine
	:	'\r'? '\n'
	;

Colon
	:	':'
	;

Ident
	:	[_a-zA-Z][_a-zA-Z0-9]*
	;

Float
	:	('+'|'-')? ( Number '.' Number? | Number? '.' Number )
	;

Integer
	:	('+'|'-')? Number
	;

Number
	:	Digit+
	;

Digit
	:	[0-9]
	;