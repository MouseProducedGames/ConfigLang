parser grammar ConfigLangParser;

options
{
	tokenVocab = ConfigLangLexer;
}

compileUnit
	:	stat*
	;

stat
	:	name=Ident Colon ( float=Float | int=Integer | id=Ident ) ( NewLine | EOF )
	;