grammar Cqrs;

/*
 * Parser Rules
 */

dictionary	
	: (projectAssignment)+ EOF
	;

projectAssignment
	: PROJECT projectName TERMINATE? 
		(namespaceAssignment)+
	;

namespaceAssignment
	: NS namespaceName TERMINATE? 
		(definitions)+
	;

definitions 
	: (
			commandDefinition
			| eventDefinition
			| valueObjectDefinition
			| dataTransferObjectDefinition
		)
	;

projectName 
	: IDENTIFIER (DOT IDENTIFIER)*
	;

namespaceName 
	: IDENTIFIER (DOT IDENTIFIER)*
	;

commandDefinition 
	: COMMAND commandName COLON fieldDefinition (COMMA fieldDefinition)* TERMINATE?
	;

commandName
	: IDENTIFIER
	;

eventDefinition 
	: EVENT eventName COLON fieldDefinition (COMMA fieldDefinition)* TERMINATE?
	;

eventName
	: IDENTIFIER
	;

valueObjectDefinition 
	: VO valueObjectName COLON fieldDefinition (COMMA fieldDefinition)* TERMINATE?
	;

valueObjectName
	: IDENTIFIER
	;

dataTransferObjectDefinition 
	: DTO dataTransferObjectName COLON fieldDefinition (COMMA fieldDefinition)* TERMINATE?
	;

dataTransferObjectName
	: IDENTIFIER
	;

fieldDefinition 
	: fieldPropertyName fieldPropertyType	
	;

fieldPropertyType
	: 
	(PREDEFINED_TYPE | IDENTIFIER)
	(OPTIONAL | REQUIRED)?
	ARRAY?
	;

fieldPropertyName
	: IDENTIFIER
	;


/*
 * Lexer Rules
 */
PROJECT				: 'project'	;
NS					: 'namespace'	;
COMMAND				: 'command-def'	;
EVENT				: 'event-def'	;
VO					: 'vo-def'	;
DTO					: 'dto-def'	;



fragment LETTER             : ('a'..'z' | 'A'..'Z')     ;
fragment DIGIT              : '0'..'9';
fragment UNDERSCORE			: '_';

/*
System.String (string)
System.Object (object)
System.SByte (sbyte)
System.Byte (byte)
System.Int16 (short)
System.UInt16 (ushort)
System.Int32 (int)
System.UInt32 (uint)
System.Int64 (long)
System.UInt64 (ulong)
System.Char (char)
System.Single (float)
System.Double (double)
System.Boolean (bool)
System.Decimal (decimal)

*/
fragment GUID_LITERAL		 : ('System.Guid' | 'Guid')	;
fragment STRING_LITERAL		 : ('string' | 'System.String' | 'String')	;
fragment OBJECT_LITERAL		 : ('object' | 'System.Object' | 'Object')	;
fragment SBYTE_LITERAL		 : ('sbyte' | 'System.SByte' | 'SByte')	;
fragment BYTE_LITERAL		 : ('byte' | 'System.Byte' | 'Byte')	;
fragment SHORT_LITERAL		 : ('short' | 'System.Int16' | 'Int16')	;
fragment USHORT_LITERAL		 : ('ushort' | 'System.UInt16' | 'UInt16')	;
fragment INT_LITERAL		 : ('int' | 'System.Int32' | 'Int32')	;
fragment UINT_LITERAL		 : ('uint' | 'System.UInt32' | 'UInt32')	;
fragment LONG_LITERAL		 : ('long' | 'System.Int64' | 'Int64')	;
fragment ULONG_LITERAL		 : ('ulong' | 'System.UInt64' | 'UInt64')	;
fragment CHAR_LITERAL		 : ('char' | 'System.Char' | 'Char')	;
fragment FLOAT_LITERAL		 : ('float' | 'System.Single' | 'Single')	;
fragment DOUBLE_LITERAL		 : ('double' | 'System.Double' | 'Double')	;
fragment BOOL_LITERAL		 : ('bool' | 'System.Boolean' | 'Boolean')	;
fragment DECIMAL_LITERAL	 : ('decimal' | 'System.Decimal' | 'Decimal')	;
fragment DATE_LITERAL		 : ('date' | 'localdate')	;
fragment TIME_LITERAL		 : ('time' | 'localtime')	;
fragment DATETIME_LITERAL	 : ('localdatetime' | 'datetime' | 'System.DateTime' | 'DateTime')	;

PREDEFINED_TYPE
	: (GUID_LITERAL
	| STRING_LITERAL
	| OBJECT_LITERAL
	| SBYTE_LITERAL
	| BYTE_LITERAL
	| SHORT_LITERAL
	| USHORT_LITERAL
	| INT_LITERAL
	| UINT_LITERAL
	| LONG_LITERAL
	| ULONG_LITERAL
	| CHAR_LITERAL
	| FLOAT_LITERAL
	| DOUBLE_LITERAL
	| BOOL_LITERAL
	| DECIMAL_LITERAL
	| DATE_LITERAL
	| TIME_LITERAL
	| DATETIME_LITERAL)
	;



INTEGER                     
	: DIGIT+
	;

IDENTIFIER                 
	: LETTER (LETTER | DIGIT | UNDERSCORE)*
	;


TERMINATE                   : ('\r\n' | '\n') ;
COMMA                       : ','   ;
DOT                         : '.'   ;
COLON						: ':'	;
REQUIRED                    : '!'   ;
OPTIONAL                    : '?'   ;
TAB							: '\t'	;
ARRAY						: '[]'	;

// handle comments and white space
MULTILINE_COMMENT           : '/*' .*? '*/' -> skip ;
COMMENT                     : '//' .*? ('\n'|'\r') -> skip  ;
WS                          : [ \t\r\n\f]+ -> skip    ;
