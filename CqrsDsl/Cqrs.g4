grammar Cqrs;

/*
 * Parser Rules
 */

dictionary	
	: projectAssignments+ EOF
	;

projectAssignments
	: (projectAssignment namespaceAssignments+)+
	;

namespaceAssignments
	: (namespaceAssignment definitions)+
	;

definitions 
	: (
			commandDefinition
			| eventDefinition
			| valueObjectDefinition
			| dataTransferObjectDefinition
		)+
	;

 
projectAssignment 
	: PROJECT projectName TERMINATE?
	;

projectName 
	: IDENTIFIER (DOT IDENTIFIER)*
	;

namespaceAssignment 
	: NS namespaceName TERMINATE?
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

fieldPropertyName
	: IDENTIFIER
	;

fieldPropertyType
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

INTEGER                     
	: DIGIT+
	;

IDENTIFIER                 
	: LETTER (LETTER | DIGIT)*
	;


TERMINATE                   : ('\r\n' | '\n') ;
COMMA                       : ','   ;
DOT                         : '.'   ;
COLON						: ':'	;
UNDERSCORE					: '_'	;
REQUIRED                    : '!'   ;
OPTIONAL                    : '?'   ;
TAB							: '\t'	;

// handle comments and white space
MULTILINE_COMMENT           : '/*' .*? '*/' -> skip ;
COMMENT                     : '//' .*? ('\n'|'\r') -> skip  ;
WS                          : [ \t\r\n\f]+ -> skip    ;
