# ConfigLang

2017-05-29

An example of how to code a configuration file reader using Antlr4

Text Format:
Identifier: ( Bool | Float | Int | Identifier )

Currently supports the following data types:
* Boolean
* Double
* Int64
* UTF-16 string identifiers

ConfigReader:
* Can check that a value exists.
* Can check the existence of an appropriate value type.
* Can read all supported data types.
* Supports an additional ConfigValue class which allows raw get/set of configuration data.
* Can read a configuration file to a class object, based on field and property names.

Does not support writing configuration files.
