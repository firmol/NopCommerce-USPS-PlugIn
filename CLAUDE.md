openapi: 3.0.1

info:

&nbsp; title: Open Authorization (OAuth 2.0) 3.0

&nbsp; description: |

&nbsp; 

&nbsp;   Contact Us: \[USPS API Support](https://emailus.usps.com/s/usps-APIs) | \[Terms of Service](https://about.usps.com/termsofuse.htm)

&nbsp; 

&nbsp;   OAuth access tokens are used to grant authorized access to USPS\&#174; APIs.

&nbsp;   Access tokens will expire, requiring applications to periodically check the expiration time and get new tokens.

&nbsp;   

&nbsp;   

&nbsp;   The following \_\_OAuth 2.0\_\_ grant types are supported:

&nbsp;   

&nbsp;   



&nbsp;   \* \_\*\*Client Credentials\*\*\_: The token request exchanges the client Id and secret to get an access token. The client Id and secret are the credentials for your client application and are validated.





&nbsp;   \* \_\*\*Refresh Token\*\*\_: The refresh token is exchanged to get a new access token and an optional refresh token. The refresh token is validated and must not have expired or been revoked.



&nbsp;   \* \_\*\*Authorization Code\*\*\_: The token request exchanges an authorization code previously received for access and refresh tokens. User (Resource Owner) authentication and consent is prerequisite for authorization code generation. The authorization code is validated and must not have expired.

&nbsp;   

&nbsp;   Other OAuth flows may become supported in future releases.

&nbsp;   

&nbsp;   

&nbsp;   You will need to add an app to get a client Id and secret. These are the \_\*\*Consumer Key\*\*\_ and \_\*\*Consumer Secret\*\*\_ values in the API developer portal.

&nbsp;   

&nbsp;   

&nbsp;   

&nbsp;   

&nbsp;   Each API will stipulate the level of authentication assurance required to access its resources, either \*Client Application\* or \*Resource Owner\* credentials.  The access token value is placed in the \*Authorization\* header in accordance with the \*Bearer\* token authentication scheme.



&nbsp;    ```

&nbsp;    Authorization: Bearer eyJhbGciOiJSUzI1NiJ9.eyJpc3MiOiJ1c3BzLmNvbSIsInN1YiI6IjI0ODI4OTc2MTAwMSIsImF1ZCI6InM2QmhkUmtxdDMiLCJub25jZSI6Im4tMFM2X1d6QTJNaiIsImV4cCI6MTMxMTI4MTk3MCwiaWF0IjoxMzExMjgwOTcwLCJuYW1lIjoiSmFuZSBEb2UiLCJnaXZlbl9uYW1lIjoiSmFuZSIsImZhbWlseV9uYW1lIjoiRG9lIiwibG9jYWxlIjoiZW4tdXMiLCJhenAiOiJ1c3BzLmNvbSIsImFjciI6IkFBTDEiLCJhbXIiOiJwd2QifQ.qJ2SUGKn4TabFfMYODW1RLxirFmeeYPDyFvuJR0ywRVaRnoe7Rlk8yKM3v2fCBUi2lMo00whNhNWmqQktpGgvkVGWXGMNIlVxJCqt\_aPFx3oOvkhKWGI49JI5NyXrpj4tfYD5pIYbrihkF7eMYG3XyqYMx1VLhhV0PmWhpq787K7\_AGfRlNVQnD\_WEHJt4SoEnsiw8vcwDWXcXr5yCzAEn8mfCSTlamqVBUyey1Fyg\_xgQIRj\_b9CO-O4kXsBM3vqo5CO2qET2tRd37niaQvV-g418sEpnw1iAtxWfcyU4IIjWlQa7AxAc3T4Vx6XOwn1CNI22ZhdaBskUtD-EexWQ



&nbsp;    ```

&nbsp;   

&nbsp;   Each API will validate the access token, its expiration in addition to its OAuth scope for example. There may be further validations required which are specific to the resource being accessed.

&nbsp;   

&nbsp;   

&nbsp;   You will need to get a new access token once the one you have has expired. It is best practice to get a new access token before expiration if further access to resources is needed.

&nbsp;   

&nbsp;   You may also revoke a refresh token which you suspect has been disclosed or dispose it when it is no longer needed.

&nbsp;     

&nbsp;   



\#  Resource Owner Password Credentials Flow omitted.    



&nbsp; version: 3.1.4



\#  OpenAPI Specification, versions 3.0.0, 3.0.1, 3.1.1 and 3.2 do not support a URL as an email address in Contact Object.



&nbsp; 

servers:

&nbsp; - url: https://apis.usps.com/oauth2/v3

&nbsp;   description: Production Environment Endpoint



&nbsp; - url: https://apis-tem.usps.com/oauth2/v3

&nbsp;   description: Testing Environment Endpoint

&nbsp; 

\# ReDoc limitation does not use Server Variable Objects in the DX UI.





tags:

&nbsp;- name:  Resources

&nbsp;  description: Defined by the IETF OAuth industry standards, see \[The OAuth 2.0 Authorization Framework](https://datatracker.ietf.org/doc/html/rfc6749).  See also \[Best Current Practice for OAuth 2.0 Security](https://datatracker.ietf.org/doc/html/rfc9700) for security awareness.

&nbsp;  

paths:



&nbsp; /token:

&nbsp;   summary: Generate OAuth tokens.

&nbsp;   description: |

&nbsp;     Issue access and refresh tokens. Based on the \\'OAuth 2.0 Authorization Framework\\', IETF Draft RFC 6749, October 2012, see \[The OAuth 2.0 Authorization Framework](https://datatracker.ietf.org/doc/html/rfc6749).

&nbsp;     

&nbsp;     The \_expires\_in\_ and \_refresh\_token\_expires\_in\_ fields in the token response specify the respective valid lifetimes for each token.



&nbsp;   post:

&nbsp;     summary: Generate OAuth tokens.

&nbsp;     description: |

&nbsp;       Issue one or more OAuth tokens for a client application to use to make subsequent resource requests.

&nbsp;       Based on the \_OAuth 2.0 Authorization Framework\_, IETF Draft RFC 6749, October 2012, see \[The OAuth 2.0 Authorization Framework](https://datatracker.ietf.org/doc/html/rfc6749).

&nbsp;       

&nbsp;       The \_expires\_in\_ and \_refresh\_token\_expires\_in\_ fields in the token response specify the respective valid lifetimes for each token.





&nbsp;       The following OAuth grant types are supported:

&nbsp;       

&nbsp;       - \*\*Client Credentials Grant\*\*, see \[IETF 6749, section 4.4](https://datatracker.ietf.org/doc/html/rfc6749#section-4.4).



&nbsp;       - \*\*Refresh Token\*\*, see \[IETF 6749, section 6](https://datatracker.ietf.org/doc/html/rfc6749#section-6)

&nbsp;               

&nbsp;       - \*\*Authorization Code Grant\*\*, see \[IETF 6749, section 4.1](https://datatracker.ietf.org/doc/html/rfc6749#section-4.1).

&nbsp;       

&nbsp;       

&nbsp;       

\#        Resource Owner Password Credentials Flow omitted.



&nbsp;     tags:

&nbsp;       - Resources

&nbsp;     operationId: post-token

&nbsp;     requestBody:

&nbsp;       description: |

&nbsp;         The input parameters corresponding to the supported grant types.

&nbsp;       content:

&nbsp;         application/json:

&nbsp;           schema:

&nbsp;             oneOf:

&nbsp;             - $ref: '#/components/schemas/ClientCredentials'

&nbsp;             - $ref: '#/components/schemas/RefreshTokenCredentials'

&nbsp;             - $ref: '#/components/schemas/AuthorizationCodeCredentials'

&nbsp;             discriminator:

&nbsp;               propertyName: grant\_type

&nbsp;               mapping:

&nbsp;                 client\_credentials: '#/components/schemas/ClientCredentials'

&nbsp;                 refresh\_token: '#/components/schemas/RefreshTokenCredentials'

&nbsp;                 authorization\_code: '#/components/schemas/AuthorizationCodeCredentials'

\#                 Resource Owner Password Credentials omitted.

&nbsp;           examples:

&nbsp;             client-credentials-grant:

&nbsp;               $ref: '#/components/examples/clientCredentialsTokenRequest'

&nbsp;             refresh-token-credentials-grant:

&nbsp;               $ref: '#/components/examples/refreshTokenCredentialsTokenRequest'

&nbsp;             authorization-code-grant:

&nbsp;               $ref: '#/components/examples/authorizationCodeTokenRequest'

&nbsp;         application/x-www-form-urlencoded:

&nbsp;           schema:

&nbsp;             oneOf:

&nbsp;             - $ref: '#/components/schemas/ClientCredentials'

&nbsp;             - $ref: '#/components/schemas/RefreshTokenCredentials'

&nbsp;             - $ref: '#/components/schemas/AuthorizationCodeCredentials'

&nbsp;             discriminator:

&nbsp;               propertyName: grant\_type

&nbsp;               mapping:

&nbsp;                 client\_credentials: '#/components/schemas/ClientCredentials'

&nbsp;                 refresh\_token: '#/components/schemas/RefreshTokenCredentials'

&nbsp;                 authorization\_code: '#/components/schemas/AuthorizationCodeCredentials'

\#                 Resource Owner Password Credentials omitted.

&nbsp;     responses:

&nbsp;       "200":

&nbsp;         description: Token Issued.

&nbsp;           Client application authorization has been granted and OAuth token(s) issued.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               oneOf:

&nbsp;               - $ref: '#/components/schemas/ClientApplicationTokenResponse'

&nbsp;               - $ref: '#/components/schemas/ResourceOwnerTokenResponse'

&nbsp;             examples:

&nbsp;               client-credentials-grant:

&nbsp;                 $ref: '#/components/examples/clientCredentialsTokenResponse'

&nbsp;               refresh-token-grant:

&nbsp;                 $ref: '#/components/examples/refreshTokenResponse'

&nbsp;               authorization-code-grant:

&nbsp;                 $ref: '#/components/examples/authorizationCodeTokenResponse'

\#                 Resource Owner Password Credentials omitted.

&nbsp;       "400":

&nbsp;         description: Bad Request.  Check the input parameters and values.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/StandardErrorResponse'

&nbsp;             examples:

&nbsp;               invalid\_refresh-token-response:

&nbsp;                 $ref: '#/components/examples/invalidRefreshTokenResponse'

&nbsp;               expired-refresh-token-response:

&nbsp;                 $ref: '#/components/examples/invalidRefreshTokenExpiredResponse'

&nbsp;               invalid-authorization-code-response:

&nbsp;                 $ref: '#/components/examples/invalidAuthorizationCodeResponse'

&nbsp;       "401":

&nbsp;         description: Unauthorized Request.  Check the authentication scheme and values being used to make the request.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/StandardErrorResponse'

&nbsp;             examples:

&nbsp;               invalid-client-identifier:

&nbsp;                 $ref: '#/components/examples/invalidClientIdentifierResponse'

&nbsp;               invalid-client-credentials:

&nbsp;                 $ref: '#/components/examples/invalidClientCredentialsResponse'

&nbsp;         headers:

&nbsp;           WWW-Authenticate:

&nbsp;             $ref: '#/components/headers/WWWAuthenticate'

&nbsp;       "429":

&nbsp;         description: Too Many Requests. Too many requests have been received from client in a short amount of time.

&nbsp;         headers:

&nbsp;           Retry-After:

&nbsp;             $ref: '#/components/headers/RetryAfter'

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/StandardErrorResponse'

&nbsp;             examples:

&nbsp;               spike-arrest-violation:

&nbsp;                 $ref: '#/components/examples/spikeArrestViolationResponse'

&nbsp;       "503":

&nbsp;         description: Service Unavailable.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/StandardErrorResponse'

&nbsp;         headers:

&nbsp;           Retry-After:

&nbsp;             $ref: '#/components/headers/RetryAfter'

&nbsp;         



&nbsp; /revoke:

&nbsp;   summary: Invalidate OAuth tokens.

&nbsp;   description: |

&nbsp;     Prevent tokens from being further used to access APIs by invalidating OAuth tokens which are no longer needed. This resource is based on the \\'OAuth 2.0 Token Revocation\\', IETF Draft RFC 7009, August 2013, see \[OAuth 2.0 Token Revocation](https://datatracker.ietf.org/doc/html/rfc7009).

&nbsp;     

&nbsp;     

&nbsp;     Basic Authentication is used to access this resource, using the issued client Id and client secret.

&nbsp;     

&nbsp;     Only refresh tokens may be revoked, since access tokens are self-contained, and formatted using JSON Web Token industry standard.

&nbsp;     

&nbsp;   post:

&nbsp;     summary: 'Invalidate OAuth tokens.'

&nbsp;     description: |

&nbsp;       Prevent tokens from being further used to access APIs by invalidating OAuth tokens which are no longer needed. This resource is based on the \\'OAuth 2.0 Token Revocation\\', IETF Draft RFC 7009, August 2013, see \[OAuth 2.0 Token Revocation](https://datatracker.ietf.org/doc/html/rfc7009).

&nbsp;       

&nbsp;      

&nbsp;       Basic Authentication is used to access this resource, using the issued client Id and client secret.

&nbsp;          

&nbsp;       ```

&nbsp;       Authorization: Basic N0MyejJiS1FodDJUTEJjVTE2VmxlZUplQm1hdExiMjQ6TENtSE85RUFENXk0bUNURA==

&nbsp;       ```

&nbsp;       

&nbsp;       

&nbsp;       Only refresh tokens may be revoked, since access tokens are self-contained, and formatted using JSON Web Token industry standard.

&nbsp;      

&nbsp;     tags:

&nbsp;       - Resources

&nbsp;     operationId: post-revoke

&nbsp;     requestBody:

&nbsp;       description: |

&nbsp;         The token to be inspected. The hint is used to locate the token.

&nbsp;       content:

&nbsp;         application/json:

&nbsp;           schema:

&nbsp;             $ref: '#/components/schemas/TokenRevokeRequest'

&nbsp;           examples:

&nbsp;             revoke-request-example:

&nbsp;               $ref: '#/components/examples/revokeTokenRequest'

&nbsp;         application/x-www-form-urlencoded:

&nbsp;           schema:

&nbsp;             $ref: '#/components/schemas/TokenRevokeRequest'

&nbsp;     security:

&nbsp;       - BasicAuth: \[ ]

&nbsp;       

&nbsp;     responses:

&nbsp;       "200":

&nbsp;         description: Successful Operation. No response payload.

&nbsp;       "400":

&nbsp;         description: Bad Request.  Check the input parameters and values.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/StandardErrorResponse'

&nbsp;             examples:

&nbsp;               expired-refresh-token-response:

&nbsp;                 $ref: '#/components/examples/invalidRefreshTokenExpiredResponse'

&nbsp;       "401":

&nbsp;         description: Unauthorized Request.  Check the authentication scheme and values being used to make the request.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/StandardErrorResponse'

&nbsp;             examples:

&nbsp;               invalid-client-identifier:

&nbsp;                 $ref: '#/components/examples/invalidClientIdentifierResponse'

&nbsp;               invalid-client-credentials:

&nbsp;                 $ref: '#/components/examples/invalidClientCredentialsResponse'

&nbsp;         headers:

&nbsp;           WWW-Authenticate:

&nbsp;             $ref: '#/components/headers/WWWAuthenticate'

&nbsp;       "429":

&nbsp;         description: Too Many Requests. Too many requests have been received from client in a short amount of time.

&nbsp;         headers:

&nbsp;           Retry-After:

&nbsp;             $ref: '#/components/headers/RetryAfter'

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/StandardErrorResponse'

&nbsp;             examples:

&nbsp;               spike-arrest-violation:

&nbsp;                 $ref: '#/components/examples/spikeArrestViolationResponse'

&nbsp;       "503":

&nbsp;         description: Service Unavailable.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/StandardErrorResponse'

&nbsp;         headers:

&nbsp;           Retry-After:

&nbsp;             $ref: '#/components/headers/RetryAfter'              



components:



&nbsp; headers:

&nbsp; 

&nbsp;   RetryAfter:

&nbsp;     description: Indicate to the client application a time after which they can retry a resource request.

&nbsp;     schema:

&nbsp;       type: string

&nbsp;       example: 'Retry-After: 30'

&nbsp;     

&nbsp;   WWWAuthenticate:

&nbsp;      description: Hint to the client application which security scheme to authorize a resource request.

&nbsp;      schema:

&nbsp;        type: string

&nbsp;        example: 'WWW-Authenticate: Bearer realm="https://api.usps.com/realms/USPS"'

&nbsp;      

&nbsp; securitySchemes:

&nbsp; 

&nbsp;   BasicAuth:

&nbsp;     description: Use the client\_id and client\_secret for the username and password, respectfully. The client application is authenticated using the Basic authentication security scheme.

&nbsp;     type: http

&nbsp;     scheme: basic

&nbsp;     

&nbsp;   BearerTokenAuth:

&nbsp;     description: An access token is used to authenticate the client application making the request.

&nbsp;     type: http

&nbsp;     scheme: bearer

&nbsp;     bearerFormat: JWT

&nbsp;     

&nbsp; schemas:

&nbsp; 

&nbsp;   TokenRequest:

&nbsp;     title:  Token Request

&nbsp;     description: The base object for an OAuth token request, in accordance with OAuth industry standards.

&nbsp;     type: object

&nbsp;     required:

&nbsp;       - grant\_type

&nbsp;     oneOf:

&nbsp;     - $ref: '#/components/schemas/AuthorizationCodeCredentials'

&nbsp;     - $ref: '#/components/schemas/ClientCredentials'

&nbsp;     - $ref: '#/components/schemas/RefreshTokenCredentials'

\#           Resource Owner Password Credentials Flow omitted.

&nbsp;     properties:

&nbsp;       grant\_type:

&nbsp;         description: The OAuth standard flow being requested by the client application.

&nbsp;         type: string

&nbsp;         enum:

&nbsp;           - client\_credentials

&nbsp;           - refresh\_token

&nbsp;           - authorization\_code

\#           Resource Owner Password Credentials Flow omitted.

&nbsp;       scope:

&nbsp;         description: |

&nbsp;           The OAuth2 scope being requested. A client application may request a subset of scope that has already been configured during registration.

&nbsp;           

&nbsp;           The default scope registered for the client application is used as default when the scope is omitted.

&nbsp;           

&nbsp;           \*\*Only specify the scope in the request when the client application requires less scope, i.e. less access to APIs, than the default.\*\*

&nbsp;         type: string

&nbsp;         default: ""

&nbsp;     additionalProperties: true

&nbsp;         



&nbsp;         

&nbsp;   ClientCredentials:

&nbsp;     title: Client Credentials Token Request

&nbsp;     description: The client credentials are used to get an access token. The credentials of the client application that are verified by the authorization server.

&nbsp;       The value of the grant\_type is 'client\_credentials'

&nbsp;     required:

&nbsp;       - client\_id

&nbsp;       - client\_secret      

&nbsp;     allOf:

&nbsp;       - $ref: '#/components/schemas/TokenRequest'

&nbsp;       - type: object

&nbsp;         properties:

&nbsp;            client\_id:

&nbsp;              description: |

&nbsp;                The unique identifier issued to the client application making the request. Used for authenticating the client application.

&nbsp;                

&nbsp;                You will need to add an app to get a client Id and secret. These are the Consumer Key and Consumer Secret values respectfully in the API developer portal.

&nbsp;              type: string

&nbsp;            client\_secret:

&nbsp;              description: |

&nbsp;                 The shared secret issued to the client application making the request. Used for authenticating the client application.



&nbsp;                 You will need to add an app to get a client Id and secret. These are the Consumer Key and Consumer Secret values respectfully in the API developer portal.

&nbsp;              type: string

&nbsp;         additionalProperties: false

&nbsp;     additionalProperties: false

&nbsp;         

&nbsp;   AuthorizationCodeCredentials:

&nbsp;     title: Authorization Code Credentials Token Request

&nbsp;     description: The client credentials in addition to the authorization code received earlier are used to get access and refresh tokens. The credentials of the client application that are verified by the authorization server.

&nbsp;       The value of the grant\_type is 'authorization\_code'.

&nbsp;     required:

&nbsp;       - code

&nbsp;       - redirect\_uri

&nbsp;     allOf:

&nbsp;       - $ref: '#/components/schemas/ClientCredentials'

&nbsp;       - type: object

&nbsp;         properties:

&nbsp;            redirect\_uri:

&nbsp;              description: |

&nbsp;                The authorization code redirect Uniform Resource Identifier (URI) for the third-party application to receive the authorization code. This is used to verify the identify of the requester. The request will not be redirected to this URI.

&nbsp;              type: string

&nbsp;            code:

&nbsp;              description:  The authorization code previously received by the client application.

&nbsp;              type: string

&nbsp;         additionalProperties: false

&nbsp;     additionalProperties: false

&nbsp;         

&nbsp;   RefreshTokenCredentials:

&nbsp;     title: Refresh Token Credentials Request

&nbsp;     description: The client credentials in addition to the refresh token received earlier are used to get access and refresh tokens. The credentials of the client application that are verified by the authorization server.

&nbsp;       The value of the grant\_type is 'refresh\_token'.

&nbsp;     required:

&nbsp;       - refresh\_token

&nbsp;     allOf:

&nbsp;       - $ref: '#/components/schemas/ClientCredentials'

&nbsp;       - type: object

&nbsp;         properties:

&nbsp;           refresh\_token:

&nbsp;             description:  The refresh token value to be used to issue a new access token.

&nbsp;             type: string

&nbsp;         additionalProperties: false

&nbsp;     additionalProperties: false

&nbsp;        

\#   Resource Owner Password Credentials omitted.



&nbsp;   TokenRevokeRequest:

&nbsp;     title: Token Revocation Request

&nbsp;     description: The token revocation request.

&nbsp;     type: object

&nbsp;     required:

&nbsp;       - token      

&nbsp;     properties:

&nbsp;       token:

&nbsp;         description: The token (a hash value).

&nbsp;         type: string

&nbsp;       token\_type\_hint:

&nbsp;         description: A hint to the type of the given token. See OAuth Token Types Hint registry, https://www.rfc-editor.org/rfc/rfc7009#section-4.1.2.1

&nbsp;         type: string

&nbsp;         enum:

&nbsp;           - 'access\_token'

&nbsp;           - 'refresh\_token'

&nbsp;         default:

&nbsp;           'refresh\_token'

&nbsp;     additionalProperties: false

&nbsp;     

&nbsp;   ClientApplicationTokenResponse:

&nbsp;     title: Client Application Token Response

&nbsp;     description: |

&nbsp;       The OAuth token response for third-party client applications to use to access USPS APIs.

&nbsp;       The access token is returned in the response. You may use \[The Unix Epoch Time Converter](https://www.epochconverter.com/) to convert access token issued at values to human readable formats.

&nbsp;       Use the public key provided in the response to verify the access token signature.



&nbsp;     readOnly: true

&nbsp;     required:

&nbsp;       - access\_token

&nbsp;       - expires\_in

&nbsp;       - token\_type      

&nbsp;     properties:

&nbsp;       access\_token:

&nbsp;         description: The access token issued to use to acess protected resources.

&nbsp;         type: string

&nbsp;       issued\_at:

&nbsp;         description: |

&nbsp;           The date and time the access token was issued, expressed in Unix epoch time in milliseconds.

&nbsp;           You may use \[The Unix Epoch Time Converter](https://www.epochconverter.com/) to convert access token issued at values to human readable formats.

&nbsp;         type: integer

&nbsp;         format: int64

&nbsp;       expires\_in:

&nbsp;         description: The expiration time of the issued access token, in seconds.

&nbsp;         type: integer

&nbsp;         example: 28799

&nbsp;       token\_type:

&nbsp;         description: The access token type provides the client with the information required to successfully utilize the access token to make a protected resource request (along with type-specific attributes).  The client MUST NOT use an access token if it does not understand the token type.

&nbsp;         type: string

&nbsp;         enum:

&nbsp;           - Bearer

&nbsp;         default: 'Bearer'

&nbsp;       status:

&nbsp;         description: The status of the access token.

&nbsp;         type: string

&nbsp;         enum:

&nbsp;           - approved

&nbsp;           - revoked

&nbsp;       issuer:

&nbsp;         description:  The authority that issued the token(s).

&nbsp;         type: string

&nbsp;         format: Uri

&nbsp;         example: 'https://api.usps.com/realms/USPS'

&nbsp;       scope:

&nbsp;         description: The OAuth scope being requested by the client application, specified as a list of space-delimited, case-sensitive strings.  If ommitted from the token request then the default scope configured for the client application is used.

&nbsp;         type: string

&nbsp;       client\_id:

&nbsp;         description:  The unique identifier for the client application.

&nbsp;         type: string

&nbsp;       application\_name:

&nbsp;         description: The name of the client application.

&nbsp;         type: string

&nbsp;       api\_products:

&nbsp;         description: The list of API products approved for use by the client application.

&nbsp;         type: string

&nbsp;       public\_key:

&nbsp;         description: The base64-encoded public cryptographic key used to validate the signature of the access token.  Validation ensures that the access token has not been tampered with and it originated from a known, trusted source.

&nbsp;         type: string

&nbsp;         format: byte

&nbsp;     additionalProperties: false

&nbsp;     

&nbsp;   ResourceOwnerTokenResponse:

&nbsp;     title: Resource Owner Token Response

&nbsp;     description: |

&nbsp;       The OAuth token response for third-party client applications to use to access USPS APIs on behalf of USPS customers.

&nbsp;       Both access and refresh tokens are returned in the response. You may use \[The Unix Epoch Time Converter](https://www.epochconverter.com/) to convert access token issued at values to human readable formats.

&nbsp;       Use the public key provided in the response to verify the access token signature.

&nbsp;       

&nbsp;     readOnly: true

&nbsp;     required:

&nbsp;       - access\_token

&nbsp;       - expires\_in

&nbsp;       - token\_type    

&nbsp;       - refresh\_token

&nbsp;       - refresh\_token\_expires\_in

&nbsp;     properties:

&nbsp;       access\_token:

&nbsp;         description: The access token issued to use to acess protected resources.

&nbsp;         type: string

&nbsp;       issued\_at:

&nbsp;         description: |

&nbsp;           The date and time the access token was issued, expressed in Unix epoch time in milliseconds.

&nbsp;           You may use \[The Unix Epoch Time Converter](https://www.epochconverter.com/) to convert access token issued at values to human readable formats.

&nbsp;         type: integer

&nbsp;         format: int64

&nbsp;       expires\_in:

&nbsp;         description: The expiration time of the issued access token, in seconds.

&nbsp;         type: integer

&nbsp;         example: 28799

&nbsp;       token\_type:

&nbsp;         description: The access token type provides the client with the information required to successfully utilize the access token to make a protected resource request (along with type-specific attributes).  The client MUST NOT use an access token if it does not understand the token type.

&nbsp;         type: string

&nbsp;         enum:

&nbsp;           - Bearer

&nbsp;         default: 'Bearer'

&nbsp;       status:

&nbsp;         description: The status of the access token.

&nbsp;         type: string

&nbsp;         enum:

&nbsp;           - approved

&nbsp;           - revoked

&nbsp;       issuer:

&nbsp;         description:  The authority that issued the token(s).

&nbsp;         type: string

&nbsp;         example: 'https://api.usps.com/realms/USPS'

&nbsp;       scope:

&nbsp;         description: The OAuth scope being requested by the client application, specified as a list of space-delimited, case-sensitive strings.  If ommitted from the token request then the default scope configured for the client application is used.

&nbsp;         type: string

&nbsp;       refresh\_token:

&nbsp;         description: The refresh token.

&nbsp;         type: string

&nbsp;       refresh\_token\_issued\_at:

&nbsp;         description: |

&nbsp;           The date and time the refresh token was issued expressed in Unix epoch time in milliseconds.

&nbsp;           You may use \[The Unix Epoch Time Converter](https://www.epochconverter.com/) to convert refresh token issued at values to human readable formats.

&nbsp;         type: integer

&nbsp;         format: int64

&nbsp;       refresh\_token\_expires\_in:

&nbsp;         description: The refresh token expiration, in seconds.

&nbsp;         type: integer

&nbsp;         example: 604799

&nbsp;       refresh\_count:

&nbsp;         description: The number of times the refresh token operation has been used.

&nbsp;         type: integer

&nbsp;       refresh\_token\_status:

&nbsp;         description: The current state of the refresh token.

&nbsp;         type: string

&nbsp;         enum:

&nbsp;           - approved

&nbsp;           - revoked

&nbsp;       client\_id:

&nbsp;         description:  The unique identifier for the client application.

&nbsp;         type: string

&nbsp;       application\_name:

&nbsp;         description: The name of the client application.

&nbsp;         type: string

&nbsp;       api\_products:

&nbsp;         description: The list of API products approved for use by the client application.

&nbsp;         type: string

&nbsp;       public\_key:

&nbsp;         description: The base64-encoded public cryptographic key used to validate the signature of the access token.  Validation ensures that the access token has not been tampered with and it originated from a known, trusted source.

&nbsp;         type: string

&nbsp;         format: byte

&nbsp;     additionalProperties: false

&nbsp;     

&nbsp;   StandardErrorResponse:

&nbsp;     title: OAuth Standard Error Response

&nbsp;     description: The authorization server responds with an HTTP 400 (Bad Request) status code (unless specified otherwise) and includes the following parameters with the response.

&nbsp;     readOnly: true

&nbsp;     type: object

&nbsp;     properties:

&nbsp;       error:

&nbsp;         description: See \[The OAuth 2.0 Authorization Framework, Section 5.2](https://datatracker.ietf.org/doc/html/rfc6749#section-5.2), for information about the specific error codes.

&nbsp;         type: string

&nbsp;         enum:

&nbsp;           - invalid\_request

&nbsp;           - invalid\_client

&nbsp;           - invalid\_grant

&nbsp;           - unauthorized\_client

&nbsp;           - unsupported\_grant\_type

&nbsp;           - invalid\_scope

&nbsp;       error\_description:

&nbsp;         description: A human-readable text providing additional information, used to assist the client developer in understanding the error that occurred.

&nbsp;         type: string

&nbsp;       error\_uri:

&nbsp;         description: A URI identifying a human-readable web page with information about the error, used to provide the client developer with additional information about the error.

&nbsp;         type: string

&nbsp;     additionalProperties: true

&nbsp;     

&nbsp; examples:

&nbsp;     

&nbsp;    clientCredentialsTokenRequest:

&nbsp;     summary: Client credentials token request example.

&nbsp;     value:

&nbsp;       {

&nbsp;         "grant\_type": "client\_credentials",

&nbsp;         "client\_id": "123456789",

&nbsp;         "client\_secret": "A1B2c3d4E5"

&nbsp;       }



&nbsp;    authorizationCodeTokenRequest:

&nbsp;     summary: Authorization code token request example.

&nbsp;     value:

&nbsp;       {

&nbsp;         "grant\_type": "authorization\_code",

&nbsp;         "client\_id": "123456789",

&nbsp;         "client\_secret": "A1B2c3d4E5",

&nbsp;         "redirect\_uri": "https://mycompany.com/authorize",

&nbsp;         "code": "EyQPFYVI"

&nbsp;       }

&nbsp;       

&nbsp;    refreshTokenCredentialsTokenRequest:

&nbsp;     summary: Refresh Token credentials token request example.

&nbsp;     value:

&nbsp;       {

&nbsp;         "grant\_type": "refresh\_token",

&nbsp;         "client\_id": "123456789",

&nbsp;         "client\_secret": "A1B2c3d4E5",

&nbsp;         "refresh\_token": "ExDTmpomcDt6pTbFVvSgQ1km39YmX8Oy"

&nbsp;       }

&nbsp;       

\#  Resource Owner Password Credentials omitted.



&nbsp;    revokeTokenRequest:

&nbsp;      summary: Token revocation request JSON example.

&nbsp;      value:

&nbsp;        {

&nbsp;        "token":"ExDTmpomcDt6pTbFVvSgQ1km39YmX8Oy",

&nbsp;        "token\_type\_hint":"refresh\_token"

&nbsp;        }



\#  Authorization code Flow (POST) omitted.

&nbsp;        

&nbsp;    clientCredentialsTokenResponse:

&nbsp;      summary: An access token is returned. The access token is self-contained and in JSON Web Token format.

&nbsp;      description: The public key provided should be used to verify the access token signature.

&nbsp;      value:

&nbsp;         {

&nbsp;             "access\_token": "eyJraWQiOiIxMDEwMTAiLCJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJzdWIiOiIiLCJhdWQiOiJhZGRyZXNzZXMgaW50ZXJuYXRpb25hbC1wcmljZXMgc3Vic2NyaXB0aW9ucyBwYXltZW50cyBwaWNrdXAgdHJhY2tpbmcgbGFiZWxzIHNjYW4tZm9ybXMgY29tcGFuaWVzIHNlcnZpY2UtZGVsaXZlcnktc3RhbmRhcmRzIGxvY2F0aW9ucyBpbnRlcm5hdGlvbmFsLWxhYmVscyBwcmljZXMiLCJhenAiOiJoeXI3YjN2Q1J0cFl0QUhNMWE4Y2RVcmt5eUZtTmtiZyIsIm9yZ2FuaXphdGlvbl9pZCI6IjAiLCJpc3MiOiJ1cm46XC9cL2FwaS51c3BzLmNvbSIsImV4cCI6MTY4MDkxNzc4NiwiaWF0IjoxNjgwODg4OTg2LCJqdGkiOiI3YjU5MzJlMS05NjIxLTQzZDAtYTMyNy0xMzIxYWVjNzJjZGYifQ.QzrUxlT2rG4jvYbMDGnk23j8ZYfHJcdXPKR9CbSmcKeVpURaHhEMpPB6K4x5ut3xxeEGSzeE5VRz8vixI4iqyHsD8rSdkLTPHy0iovUHOZQBAJVQ6hii9jpLhxUXmiTtH3jKzSj\_f2fuNmZbIGhf-CR2FBeWF-aBPzEDEMV95nkCUMfW\_Z2BmkbraSfvQZxkCO-cLrMAwlYcrzUtaJ7vnazeQB4sep5BBHBEvsa4kfq6\_tz6BAKgv3R7cI2NkSv-wgy\_IGoTjVCMTS8mJHGs\_t8cWCO8-z4lxW1tUwIBKOCUDpmEEnGgiG6Sl0C\_gGl4bZ5cDSl4IgPpcOVi9jZ7LA",

&nbsp;             "token\_type": "Bearer",

&nbsp;             "issued\_at": 1680888985929,

&nbsp;             "expires\_in": 28799,

&nbsp;             "status": "approved",

&nbsp;             "scope": "addresses international-prices subscriptions payments pickup tracking labels scan-forms companies service-delivery-standards locations international-labels prices",

&nbsp;             "issuer": "https://api.usps.com/realms/USPS",

&nbsp;             "client\_id": "hyr7b3vCRtpYtAHM1a8cdUrkyyFmNkbg",

&nbsp;             "application\_name": "Silver Shipper Developer",

&nbsp;             "api\_products": "\[Shipping-Silver]",

&nbsp;             "public\_key": "LS0tLS1CRUdJTiBQVUJMSUMgS0VZLS0tLS0KTUlJQklqQU5CZ2txaGtpRzl3MEJBUUVGQUFPQ0FROEFNSUlCQ2dLQ0FRRUF4QWxwZjNSNEE1S0lwZnhJVWk1bgpMTFByZjZVZTV3MktzeGxSVzE1UWV0UzBjWGVxaW9OT2hXbDNaaVhEWEdKT3ZuK3RoY0NWVVQ3WC9JZWYvTENZCkhUWk1kYUJOdW55VHEwT2RNZmVkUU8zYUNKZmwvUnJPTHYyaG9TRDR4U1YxRzFuTTc1RTlRYitFZ1p0cmFEUXoKNW42SXRpMUMzOHFGMjU5NVRHUWVUemx3Wk1LQng1VTY2bGwzNzlkZ2plTUJxS3ppVHZHWEpOdVg5ZzRrRlBIaApTLzNERm9FNkVFSW8zUHExeDlXTnRaSm93VkRwQUVZZTQ3SU1UdXJDN2NGcXp2d3M1b1BDRHQ4c083N2lUdDN0Cm1vK3NrM2ExWnZSaGs2WUQ3Zkt1UldQVzFEYUM4dC9pazlnWnhqQndYNlZsSUhDRzRZSHlYejZteWdGV09jMmEKOVFJREFRQUIKLS0tLS1FTkQgUFVCTElDIEtFWS0tLS0t"

&nbsp;         }



&nbsp;    authorizationCodeTokenResponse:

&nbsp;       summary: An access token and a new refresh token has been issued.  Indicates the refresh token count.

&nbsp;       description: The public key provided should be used to verify the access token signature. The refresh token is an opaque value that is managed internally.

&nbsp;       value:

&nbsp;         {

&nbsp;           "access\_token": "eyJraWQiOiIxMDEwMTAiLCJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJzdWIiOiIiLCJhdWQiOiJhZGRyZXNzZXMgaW50ZXJuYXRpb25hbC1wcmljZXMgc3Vic2NyaXB0aW9ucyBwYXltZW50cyBwaWNrdXAgdHJhY2tpbmcgbGFiZWxzIHNjYW4tZm9ybXMgY29tcGFuaWVzIHNlcnZpY2UtZGVsaXZlcnktc3RhbmRhcmRzIGxvY2F0aW9ucyBpbnRlcm5hdGlvbmFsLWxhYmVscyBwcmljZXMiLCJhenAiOiIiLCJtYWlsX293bmVycyI6IiIsInBheW1lbnRfYWNjb3VudHMiOiIiLCJpc3MiOiJ1cm46XC9cL2FwaS51c3BzLmNvbSIsImNvbnRyYWN0cyI6IiIsImV4cCI6MTY4MDkxODQyOCwiaWF0IjoxNjgwODg5NjI4LCJqdGkiOiI4ODQyOGNhNy1kMTE2LTQ1YWUtOWE2Ny1kMThkNDExOGJhNWQifQ.TTJh01hL8TGSyHTL4pf7ilAeTcAfndNGyhKdGs14jRzzV70PcqqGS3PZHLiCqq65LF3kJLGGniciNWH4dc3mVNPKmgvzcIWR73ezS-a\_BDoxx9DmkqJF6ur4OsnsYQyKbhHqAf9iddnK4QRv6NN8fKHfBVmSCHEq4gcJ0zKV\_HhBSE-DgeTWSOACeYt3zBRmuhfgwL40Eb9jV8cSdawyLGgQWEvvZoq7eai\_f5gMJAcadLZ9Y-x\_YSbJ0zUjU-J1kD-ngeogb66QoM1TYKIa\_oqkFa6rtybZeeUZdmzxNLwj8ahQXy6EPA9qnPTdm1y03k-Mxh9O4JZPALDBNi5y1A",

&nbsp;           "token\_type": "Bearer",

&nbsp;           "issued\_at": 1680889628876,

&nbsp;           "expires\_in": 28799,

&nbsp;           "status": "approved",

&nbsp;           "scope": "addresses international-prices subscriptions payments pickup tracking labels scan-forms companies service-delivery-standards locations international-labels prices",

&nbsp;           "issuer": "https://api.usps.com/realms/USPS",

&nbsp;           "refresh\_token": "hqhm7KuTJKzmvhCbRzKNbkgdFlw7kU18",

&nbsp;           "refresh\_token\_issued\_at": 1680889628876,

&nbsp;           "refresh\_token\_status": "approved",

&nbsp;           "refresh\_token\_expires\_in": 604799,

&nbsp;           "refresh\_count": 1,

&nbsp;           "client\_id": "hyr7b3vCRtpYtAHM1a8cdUrkyyFmNkbg",

&nbsp;           "application\_name": "Silver Shipper Developer",

&nbsp;           "api\_products": "\[Shipping-Silver]",

&nbsp;           "public\_key": "LS0tLS1CRUdJTiBQVUJMSUMgS0VZLS0tLS0KTUlJQklqQU5CZ2txaGtpRzl3MEJBUUVGQUFPQ0FROEFNSUlCQ2dLQ0FRRUF4QWxwZjNSNEE1S0lwZnhJVWk1bgpMTFByZjZVZTV3MktzeGxSVzE1UWV0UzBjWGVxaW9OT2hXbDNaaVhEWEdKT3ZuK3RoY0NWVVQ3WC9JZWYvTENZCkhUWk1kYUJOdW55VHEwT2RNZmVkUU8zYUNKZmwvUnJPTHYyaG9TRDR4U1YxRzFuTTc1RTlRYitFZ1p0cmFEUXoKNW42SXRpMUMzOHFGMjU5NVRHUWVUemx3Wk1LQng1VTY2bGwzNzlkZ2plTUJxS3ppVHZHWEpOdVg5ZzRrRlBIaApTLzNERm9FNkVFSW8zUHExeDlXTnRaSm93VkRwQUVZZTQ3SU1UdXJDN2NGcXp2d3M1b1BDRHQ4c083N2lUdDN0Cm1vK3NrM2ExWnZSaGs2WUQ3Zkt1UldQVzFEYUM4dC9pazlnWnhqQndYNlZsSUhDRzRZSHlYejZteWdGV09jMmEKOVFJREFRQUIKLS0tLS1FTkQgUFVCTElDIEtFWS0tLS0t"

&nbsp;       }

&nbsp;

&nbsp;         

\#  Resource Owner Password Credentials Flow omitted.



&nbsp;    refreshTokenResponse:

&nbsp;       summary: An access token and a new refresh token has been issued.  Indicates the refresh token count.

&nbsp;       description: The public key provided should be used to verify the access token signature. The refresh token is an opaque value that is managed internally.

&nbsp;       value:

&nbsp;         {

&nbsp;           "access\_token": "eyJraWQiOiIxMDEwMTAiLCJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJzdWIiOiIiLCJhdWQiOiJhZGRyZXNzZXMgaW50ZXJuYXRpb25hbC1wcmljZXMgc3Vic2NyaXB0aW9ucyBwYXltZW50cyBwaWNrdXAgdHJhY2tpbmcgbGFiZWxzIHNjYW4tZm9ybXMgY29tcGFuaWVzIHNlcnZpY2UtZGVsaXZlcnktc3RhbmRhcmRzIGxvY2F0aW9ucyBpbnRlcm5hdGlvbmFsLWxhYmVscyBwcmljZXMiLCJhenAiOiIiLCJtYWlsX293bmVycyI6IiIsInBheW1lbnRfYWNjb3VudHMiOiIiLCJpc3MiOiJ1cm46XC9cL2FwaS51c3BzLmNvbSIsImNvbnRyYWN0cyI6IiIsImV4cCI6MTY4MDkxODQyOCwiaWF0IjoxNjgwODg5NjI4LCJqdGkiOiI4ODQyOGNhNy1kMTE2LTQ1YWUtOWE2Ny1kMThkNDExOGJhNWQifQ.TTJh01hL8TGSyHTL4pf7ilAeTcAfndNGyhKdGs14jRzzV70PcqqGS3PZHLiCqq65LF3kJLGGniciNWH4dc3mVNPKmgvzcIWR73ezS-a\_BDoxx9DmkqJF6ur4OsnsYQyKbhHqAf9iddnK4QRv6NN8fKHfBVmSCHEq4gcJ0zKV\_HhBSE-DgeTWSOACeYt3zBRmuhfgwL40Eb9jV8cSdawyLGgQWEvvZoq7eai\_f5gMJAcadLZ9Y-x\_YSbJ0zUjU-J1kD-ngeogb66QoM1TYKIa\_oqkFa6rtybZeeUZdmzxNLwj8ahQXy6EPA9qnPTdm1y03k-Mxh9O4JZPALDBNi5y1A",

&nbsp;           "token\_type": "Bearer",

&nbsp;           "issued\_at": 1680889628876,

&nbsp;           "expires\_in": 28799,

&nbsp;           "status": "approved",

&nbsp;           "scope": "addresses international-prices subscriptions payments pickup tracking labels scan-forms companies service-delivery-standards locations international-labels prices",

&nbsp;           "issuer": "https://api.usps.com/realms/USPS",

&nbsp;           "refresh\_token": "hqhm7KuTJKzmvhCbRzKNbkgdFlw7kU18",

&nbsp;           "refresh\_token\_issued\_at": 1680889628876,

&nbsp;           "refresh\_token\_status": "approved",

&nbsp;           "refresh\_token\_expires\_in": 604799,

&nbsp;           "refresh\_count": 1,

&nbsp;           "client\_id": "hyr7b3vCRtpYtAHM1a8cdUrkyyFmNkbg",

&nbsp;           "application\_name": "Silver Shipper Developer",

&nbsp;           "api\_products": "\[Shipping-Silver]",

&nbsp;           "public\_key": "LS0tLS1CRUdJTiBQVUJMSUMgS0VZLS0tLS0KTUlJQklqQU5CZ2txaGtpRzl3MEJBUUVGQUFPQ0FROEFNSUlCQ2dLQ0FRRUF4QWxwZjNSNEE1S0lwZnhJVWk1bgpMTFByZjZVZTV3MktzeGxSVzE1UWV0UzBjWGVxaW9OT2hXbDNaaVhEWEdKT3ZuK3RoY0NWVVQ3WC9JZWYvTENZCkhUWk1kYUJOdW55VHEwT2RNZmVkUU8zYUNKZmwvUnJPTHYyaG9TRDR4U1YxRzFuTTc1RTlRYitFZ1p0cmFEUXoKNW42SXRpMUMzOHFGMjU5NVRHUWVUemx3Wk1LQng1VTY2bGwzNzlkZ2plTUJxS3ppVHZHWEpOdVg5ZzRrRlBIaApTLzNERm9FNkVFSW8zUHExeDlXTnRaSm93VkRwQUVZZTQ3SU1UdXJDN2NGcXp2d3M1b1BDRHQ4c083N2lUdDN0Cm1vK3NrM2ExWnZSaGs2WUQ3Zkt1UldQVzFEYUM4dC9pazlnWnhqQndYNlZsSUhDRzRZSHlYejZteWdGV09jMmEKOVFJREFRQUIKLS0tLS1FTkQgUFVCTElDIEtFWS0tLS0t"

&nbsp;         }

&nbsp;         

&nbsp;    invalidClientIdentifierResponse:

&nbsp;      summary: Unknown client identifier.

&nbsp;      description: The client identifier included in the request is missing, unknown or malformed.

&nbsp;      value:

&nbsp;         {

&nbsp;           "error": "invalid\_client",

&nbsp;           "error\_description": "InvalidApiKey: The client application credentials provided in the request are missing, invalid, inactive or not approved for access.",

&nbsp;           "error\_uri": "https://datatracker.ietf.org/doc/html/rfc6749#page-45"

&nbsp;        }

&nbsp;         

&nbsp;    invalidClientCredentialsResponse:

&nbsp;      summary:  Client authentication failed.

&nbsp;      description: The client credentials included in the request could not be authenticated.

&nbsp;      value:

&nbsp;          {

&nbsp;           "error": "invalid\_client",

&nbsp;           "error\_description": "Client authentication failed.",

&nbsp;           "error\_uri": "https://datatracker.ietf.org/doc/html/rfc6749#page-45"

&nbsp;          }

&nbsp;          

&nbsp;    invalidRefreshTokenResponse:

&nbsp;      summary:  Invalid refresh token value.

&nbsp;      description: The refresh token value included in the request is missing, already used or is malformed. The refresh token value may have been previously used to get an access token and is no longer valid.

&nbsp;      value:

&nbsp;          {

&nbsp;           "error": "invalid\_request",

&nbsp;           "error\_description": "Invalid Refresh Token: Check the value of the refresh token. It may be missing, have expired or have been revoked.",

&nbsp;           "error\_uri": "https://datatracker.ietf.org/doc/html/rfc7009#section-2.2.1",

&nbsp;           "refresh\_token": "Pvd2R5rrzCMKAeeV4yMfrNOtiVVWVZh",

&nbsp;           "refresh\_token\_status": "Not Found"

&nbsp;         }

&nbsp;         

&nbsp;    invalidRefreshTokenExpiredResponse:

&nbsp;       summary: Expired refresh token.

&nbsp;       description: The refresh token specified in the request is missing, invalid or has expired.

&nbsp;       value:

&nbsp;         {

&nbsp;           "error": "invalid\_request",

&nbsp;           "error\_description": "refresh\_token\_expired: Check the value of the refresh token. It may be missing, have expired or have been revoked.",

&nbsp;           "error\_uri": "https://datatracker.ietf.org/doc/html/rfc7009#section-2.2.1",

&nbsp;           "refresh\_token": "Pvd2R5rrzCMKAeeV4yMfrNOtiVVWVZh",

&nbsp;           "refresh\_token\_status": "expired"

&nbsp;         }

&nbsp;         

&nbsp;    invalidAuthorizationCodeResponse:

&nbsp;       summary: Invalid Authorization Code.

&nbsp;       description: The authorization code included in the request is invalid, expired or malformed.

&nbsp;       value:

&nbsp;          {

&nbsp;             "error": "invalid\_request",

&nbsp;             "error\_description": "Authorizaton Code Error: either the authorization code has expired, is invalid, or the redirect\_uri is not registered.",

&nbsp;             "error\_uri": "https://datatracker.ietf.org/doc/html/rfc7009#section-2.2.1"

&nbsp;         }

&nbsp;         

&nbsp;    spikeArrestViolationResponse:

&nbsp;       summary:  Too many requests have been recieved from a given client in a short period of time.

&nbsp;       description: The Retry-After header specifies the time after which requests may resume.

&nbsp;       value:

&nbsp;         {

&nbsp;           "error": "invalid\_request",

&nbsp;           "error\_description": "SpikeArrestViolation: Too many requests received from client in a short time.",

&nbsp;           "error\_uri": "https://datatracker.ietf.org/doc/html/rfc6585#section-4"

&nbsp;         }

&nbsp;

&nbsp;    invalidRedirectUriResponse:

&nbsp;       summary: The redirect URI is invalid.

&nbsp;       description: The redirect URI value is not one that is registered to the client application making the request.

&nbsp;       value:

&nbsp;        {

&nbsp;           "error": "invalid\_request",

&nbsp;           "error\_description": "The redirect\_uri is invalid.",

&nbsp;           "error\_uri": "https://datatracker.ietf.org/doc/html/rfc6749#section-4.1.2.1"

&nbsp;        }

&nbsp;       

&nbsp;    invalidBearerToken:

&nbsp;       summary: The bearer token is invalid.

&nbsp;       description: The bearer token must be included in the authorization header using the 'Bearer' authentication scheme.

&nbsp;       value:

&nbsp;         {

&nbsp;           "error": "invalid\_client",

&nbsp;           "error\_description": "Client authentication failed, reason InvalidToken.",

&nbsp;           "error\_uri": "https://datatracker.ietf.org/doc/html/rfc6749#page-45"

&nbsp;         }

&nbsp;         

&nbsp;    unauthorizedClientApplication:

&nbsp;       summary: Unauthorized Client Access.

&nbsp;       description: The client application is not authorized to access the resource.

&nbsp;       value:

&nbsp;        {

&nbsp;           "error": "unauthorized\_client",

&nbsp;           "error\_description": "The client does not have access rights to the content.",

&nbsp;           "error\_uri": "https://datatracker.ietf.org/doc/html/rfc6749#section-5.2"

&nbsp;        }









openapi: 3.0.0

info:

&nbsp; title: Shipping Options

&nbsp; description: |

&nbsp;   Contact Us: \[USPS API Support](https://emailus.usps.com/s/usps-APIs) | \[Terms of Service](https://about.usps.com/termsofuse.htm)

&nbsp;   

&nbsp;   Find all relevant shipping options, rates, and service standards.

&nbsp; version: 3.1.26

servers:

\- url: https://apis.usps.com/shipments/v3

&nbsp; description: Production Environment Endpoint

\- url: https://apis-tem.usps.com/shipments/v3

&nbsp; description: Testing Environment Endpoint

paths:

&nbsp; /options/search:

&nbsp;   post:

&nbsp;     tags:

&nbsp;     - Resources

&nbsp;     summary: Presents options for shipping a package

&nbsp;     description: |-

&nbsp;       Based on the inputs below, the API generates a comprehensive list of shipping options that comply with USPS Shipping Standards, all within a single request.

&nbsp;       

&nbsp;       For deliveries with international mail classes, there are no commitments.  International delivery may vary based upon origin, destination, and customs delays.  For more details, visit \[International Mail \& Shipping Services](https://www.usps.com/international/mail-shipping-services.htm).



&nbsp;       For deliveries with return mail classes, there are no commitments.  Return delivery will vary based upon when the return item is entered into the mailstream.  For more details, visit \[Managing Customer Returns](https://www.usps.com/business/return-services.htm).

&nbsp;       

&nbsp;       APO, DPO, and FPO locations typically do not offer commitments.  For more details, visit \[Military \& Diplomatic Mail](https://www.usps.com/ship/apo-fpo-dpo.htm).

&nbsp;       

&nbsp;         | Element                          | Description |

&nbsp;         | -------------------------------- | --------|

&nbsp;         | \*\*originZIPCode\*\*                | The origin ZIP Code\&#8482; is where the package is being mailed from and is used for calculating pricing. |

&nbsp;         | \*\*destinationZIPCode\*\*           | The destination ZIP Code\&#8482; of the recipient is used for calculating pricing. |

&nbsp;         | \*\*destinationEntryFacilityType\*\* | The Destination Entry Facility Type the package will be mailed from and is used in calculating Shipping Standards. |

&nbsp;         | \*\*packageDescription\*\*           | Package characteristics used to price the shipment including requested mail class, weight, dimensions, and more. |

&nbsp;         | \*\*pricingOptions\*\*               | Pricing options such as price type and supporting information needed for pricing the shipping option. |

&nbsp;     operationId: post-options-search

&nbsp;     requestBody:

&nbsp;       content:

&nbsp;         application/json:

&nbsp;           schema:

&nbsp;             $ref: '#/components/schemas/OptionsRequest'

&nbsp;         application/xml:

&nbsp;           schema:

&nbsp;             $ref: '#/components/schemas/OptionsRequest'

&nbsp;       required: true

&nbsp;     responses:

&nbsp;       "200":

&nbsp;         description: Successful operation

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/OptionsResponse'

&nbsp;             examples:

&nbsp;               DomesticOutboundOptionsExample:

&nbsp;                 $ref: '#/components/examples/DomesticOutboundOptionsExample'

&nbsp;               DomesticReturnOptionsExample:

&nbsp;                 $ref: '#/components/examples/DomesticReturnOptionsExample'

&nbsp;               InternationalOptionsExample:

&nbsp;                 $ref: '#/components/examples/InternationalOptionsExample'

&nbsp;             encoding:

&nbsp;               metadata:

&nbsp;                 contentType: application/json

&nbsp;                 style: form

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/OptionsResponse'

&nbsp;             examples:

&nbsp;               DomesticOutboundOptionsExample:

&nbsp;                 $ref: '#/components/examples/DomesticOutboundOptionsExample'

&nbsp;               InternationalOptionsExample:

&nbsp;                 $ref: '#/components/examples/InternationalOptionsExample'

&nbsp;             encoding:

&nbsp;               metadata:

&nbsp;                 contentType: application/xml

&nbsp;                 style: form

&nbsp;       "400":

&nbsp;         description: Bad Request.  There is an error in the received request.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "401":

&nbsp;         description: Unauthorized request.

&nbsp;         headers:

&nbsp;           WWW-Authenticate:

&nbsp;             $ref: '#/components/headers/WWWAuthenticate'

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "403":

&nbsp;         description: Access is denied.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "429":

&nbsp;         description: Too Many Requests. Too many requests have been received from client in a short amount of time.

&nbsp;         headers:

&nbsp;           Retry-After:

&nbsp;             $ref: '#/components/headers/RetryAfter'

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "503":

&nbsp;         description: Service is unavailable

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       default:

&nbsp;         description: Other unanticipated errors that may occur.

&nbsp;         content: {}

&nbsp;     security:

&nbsp;       - OAuth:

&nbsp;           - shipments

components:

&nbsp; schemas:

&nbsp;   OptionsRequest:

&nbsp;     description: All ingredients requested to calculate pricing based on USPS service standards.

&nbsp;     oneOf:

&nbsp;     - $ref: '#/components/schemas/DomesticOptionsRequest'

&nbsp;     - $ref: '#/components/schemas/InternationalOptionsRequest'

&nbsp;   DomesticOptionsRequest:

&nbsp;     title: Domestic Options Request

&nbsp;     description: Domestic Options Request

&nbsp;     required:

&nbsp;     - destinationZIPCode

&nbsp;     - originZIPCode

&nbsp;     - packageDescription

&nbsp;     - pricingOptions

&nbsp;     type: object

&nbsp;     properties:

&nbsp;       pricingOptions:

&nbsp;         description: List of domestic pricing options

&nbsp;         minItems: 1

&nbsp;         type: array

&nbsp;         items:

&nbsp;           $ref: '#/components/schemas/DomesticPricingOption'

&nbsp;       originZIPCode:

&nbsp;         $ref: '#/components/schemas/originZIPCode'

&nbsp;       destinationZIPCode:

&nbsp;         $ref: '#/components/schemas/destinationZIPCode'

&nbsp;       destinationEntryFacilityType:

&nbsp;         type: string

&nbsp;         description: |

&nbsp;           Types of Facilities:

&nbsp;         

&nbsp;           \* NONE - Translate to Destination Rate Indicator N

&nbsp;           \* DESTINATION\_NETWORK\_DISTRIBUTION\_CENTER - Translate to Destination Rate Indicator B

&nbsp;           \* DESTINATION\_SECTIONAL\_CENTER\_FACILITY - Translate to Destination Rate Indicator S

&nbsp;           \* DESTINATION\_DELIVERY\_UNIT - Translate to Destination Rate Indicator D

&nbsp;           \* DESTINATION\_SERVICE\_HUB - Translate to Destination Rate Indicator H

&nbsp;           \* DESTINATION\_REGIONAL\_PROCESSING\_DISTRIBUTION\_CENTER - Translate to Destination Rate Indicator B



&nbsp;           Note:

&nbsp;           - The Destination Entry Facility Type is only used in calculating Shipping Standards.

&nbsp;           - Effective 01/18/2026: `DESTINATION\_NETWORK\_DISTRIBUTION\_CENTER` with `PARCEL\_SELECT` is no longer eligible.

&nbsp;           - Effective 01/18/2026: (NSA Only) `DESTINATION\_REGIONAL\_PROCESSING\_DISTRIBUTION\_CENTER` with `PARCEL\_SELECT` is available as an option.

&nbsp;         enum:

&nbsp;         - NONE

&nbsp;         - DESTINATION\_NETWORK\_DISTRIBUTION\_CENTER

&nbsp;         - DESTINATION\_SECTIONAL\_CENTER\_FACILITY

&nbsp;         - DESTINATION\_DELIVERY\_UNIT

&nbsp;         - DESTINATION\_SERVICE\_HUB

&nbsp;         - DESTINATION\_REGIONAL\_PROCESSING\_DISTRIBUTION\_CENTER

&nbsp;         default: NONE

&nbsp;       packageDescription:

&nbsp;         $ref: '#/components/schemas/DomesticPackageDescription'

&nbsp;       shippingFilter:

&nbsp;         type: string

&nbsp;         description: A filter for domestic results to return only one response based on lowest price or fastest service standard

&nbsp;         enum:

&nbsp;         - PRICE

&nbsp;         - SERVICE\_STANDARDS

&nbsp;     additionalProperties: false

&nbsp;   InternationalOptionsRequest:

&nbsp;     title: International Options Request

&nbsp;     description: International Options Request

&nbsp;     required:

&nbsp;     - destinationCountryCode

&nbsp;     - originZIPCode

&nbsp;     - packageDescription

&nbsp;     - pricingOptions

&nbsp;     type: object

&nbsp;     properties:

&nbsp;       pricingOptions:

&nbsp;         description: List of international pricing options

&nbsp;         minItems: 1

&nbsp;         type: array

&nbsp;         items:

&nbsp;           $ref: '#/components/schemas/InternationalPricingOption'

&nbsp;       originZIPCode:

&nbsp;         $ref: '#/components/schemas/originZIPCode'

&nbsp;       foreignPostalCode:

&nbsp;         $ref: '#/components/schemas/postalCode'

&nbsp;       destinationCountryCode:

&nbsp;         type: string

&nbsp;         pattern: ^\[A-Z]{2}$

&nbsp;         description: The ISO 3166-1 alpha-2 code representing the shipping destination.

&nbsp;         example: "CA"

&nbsp;       packageDescription:

&nbsp;         $ref: '#/components/schemas/InternationalPackageDescription'

&nbsp;       shippingFilter:

&nbsp;         type: string

&nbsp;         description: A filter for international results to return only one response based on lowest price.  There are no service standards for international.

&nbsp;         enum:

&nbsp;         - PRICE

&nbsp;       requestDutiesTaxesFees:

&nbsp;         type: boolean

&nbsp;         description: 'When `true` the returned `rateOption` elements will include the duties and taxes cost for each item and package fees.'

&nbsp;         default: false

&nbsp;       destinationCity:

&nbsp;         type: string

&nbsp;         maxLength: 28

&nbsp;         minLength: 1

&nbsp;         description: 'When `requestDutiesTaxesFees` is `true` then `destinationCity` may be required based on the country of import.'

&nbsp;       destinationState:

&nbsp;         type: string

&nbsp;         maxLength: 2

&nbsp;         minLength: 2

&nbsp;         pattern: "^\\\\w{2}$"

&nbsp;         description: 'When `requestDutiesTaxesFees` is `true` then `destinationState` may be required based on the country of import.'

&nbsp;       items:

&nbsp;         type: array

&nbsp;         maxItems: 30

&nbsp;         description: 'A list of items utilized for pricing when `requestDutiesTaxesFees` is `true`.'

&nbsp;         items:

&nbsp;           $ref: '#/components/schemas/InternationalOptionsRequestLandedCostItem'

&nbsp;     additionalProperties: false

&nbsp;   InternationalOptionsRequestLandedCostItem:

&nbsp;     title: Delivery Duties, Taxes, and Fees Item

&nbsp;     description: 'When `requestDutiesTaxesFees` is true at least one item is required.'

&nbsp;     type: object

&nbsp;     required:

&nbsp;       - itemId

&nbsp;       - itemValue

&nbsp;       - itemQuantity

&nbsp;     properties:

&nbsp;       itemId:

&nbsp;         type: string

&nbsp;         maxLength: 20

&nbsp;         minLength: 1

&nbsp;         pattern: "^\\\\w{1,20}$"

&nbsp;         description: 'A user-provided item identifier. The itemId is echoed in the response to correlate duties and taxes to this item.'

&nbsp;         example: "001"

&nbsp;       itemValue:

&nbsp;         maximum: 999999.99

&nbsp;         minimum: 0.01

&nbsp;         type: number

&nbsp;         format: float

&nbsp;         description: 'The value of the item.'

&nbsp;       itemQuantity:

&nbsp;         minimum: 1

&nbsp;         type: number

&nbsp;         description: 'The quantity of the item.'

&nbsp;         example: 3

&nbsp;       itemWeight:

&nbsp;         minimum: 0.001

&nbsp;         type: number

&nbsp;         description: The calculated weight for each individual item within a quantity based on user input.

&nbsp;         format: double

&nbsp;         example: 5

&nbsp;       countryOfOrigin:

&nbsp;         pattern: "\[A-Z]{2}"

&nbsp;         type: string

&nbsp;         description: 'A two digit Alpha Country Code defined by ISO representing where the item is from.'

&nbsp;         example: 'CA'

&nbsp;       HSTariffNumber:

&nbsp;         maxLength: 14

&nbsp;         minLength: 6

&nbsp;         type: string

&nbsp;         description: 'The HS tariff number is based on the Harmonized Commodity Description and Coding System developed by the World Customs Organization.  The value should follow the regular expression pattern: `^\\.\*(?:\[A-Za-z\\d]\\.\*){6,14}$`.  For more information, see: \[https://hts.usitc.gov/current](https://hts.usitc.gov/current).'

&nbsp;   OptionsResponse:

&nbsp;     type: object

&nbsp;     description: The response type varies depending on which request is passed

&nbsp;     oneOf:

&nbsp;     - $ref: '#/components/schemas/DomesticOptionsResponse'

&nbsp;     - $ref: '#/components/schemas/InternationalOptionsResponse'

&nbsp;   DomesticOptionsResponse:

&nbsp;     type: object

&nbsp;     properties:

&nbsp;       originZIPCode:

&nbsp;         pattern: "^\\\\d{5}(?:\[-\\\\s]\\\\d{4})?$"

&nbsp;         type: string

&nbsp;         description: This is the originating ZIP Code\&#8482; for the package.

&nbsp;       destinationZIPCode:

&nbsp;         pattern: "^\\\\d{5}(?:\[-\\\\s]\\\\d{4})?$"

&nbsp;         type: string

&nbsp;         description: This is the destination ZIP Code\&#8482; for the package.

&nbsp;       pricingOptions:

&nbsp;         description: List of domestic pricing options

&nbsp;         type: array

&nbsp;         xml:

&nbsp;           name: pricingOptions

&nbsp;           wrapped: true

&nbsp;         items:

&nbsp;           $ref: '#/components/schemas/DomesticPricingOption'

&nbsp;     additionalProperties: false

&nbsp;     description: TBD

&nbsp;   InternationalOptionsResponse:

&nbsp;     type: object

&nbsp;     properties:

&nbsp;       originZIPCode:

&nbsp;         pattern: "^\\\\d{5}(?:\[-\\\\s]\\\\d{4})?$"

&nbsp;         type: string

&nbsp;         description: This is the originating ZIP Code\&#8482; for the package.

&nbsp;       foreignPostalCode:

&nbsp;         $ref: '#/components/schemas/postalCode'

&nbsp;       destinationCountryCode:

&nbsp;         type: string

&nbsp;         description: Country of destination.

&nbsp;       pricingOptions:

&nbsp;         description: List of international pricing options

&nbsp;         type: array

&nbsp;         xml:

&nbsp;           name: pricingOptions

&nbsp;           wrapped: true

&nbsp;         items:

&nbsp;           $ref: '#/components/schemas/InternationalPricingOption'

&nbsp;     additionalProperties: false

&nbsp;     description: TBD

&nbsp;   DomesticOptions:

&nbsp;     type: object

&nbsp;     properties:

&nbsp;       mailClass:

&nbsp;         $ref: "#/components/schemas/DomesticMailClass"

&nbsp;       rateOptions:

&nbsp;         description: List of domestic rate options

&nbsp;         type: array

&nbsp;         xml:

&nbsp;           name: rateOptions

&nbsp;           wrapped: true

&nbsp;         items:

&nbsp;           $ref: '#/components/schemas/DomesticRateOptions'

&nbsp;     additionalProperties: false

&nbsp;     description: TBD

&nbsp;     xml:

&nbsp;       name: shippingOption

&nbsp;       wrapped: true

&nbsp;   InternationalOptions:

&nbsp;     description: Options specific to international shipments

&nbsp;     type: object

&nbsp;     properties:

&nbsp;       mailClass:

&nbsp;         $ref: "#/components/schemas/InternationalMailClass"

&nbsp;       rateOptions:

&nbsp;         description: List of rate options

&nbsp;         type: array

&nbsp;         xml:

&nbsp;           name: rateOptions

&nbsp;           wrapped: true

&nbsp;         items:

&nbsp;           $ref: '#/components/schemas/InternationalRateOptions'

&nbsp;     additionalProperties: false

&nbsp;     xml:

&nbsp;       name: shippingOption

&nbsp;       wrapped: true

&nbsp;   InternationalRateOptions:

&nbsp;     type: object

&nbsp;     description: Options for international rate

&nbsp;     allOf:

&nbsp;     - type: object

&nbsp;       properties:

&nbsp;         dutiesTaxesFeesQuote:

&nbsp;           $ref: '#/components/schemas/DutiesTaxesFeesQuote'

&nbsp;     - $ref: '#/components/schemas/RateOptions'

&nbsp;   DomesticRateOptions:

&nbsp;     type: object

&nbsp;     description: Options for domestic rate

&nbsp;     allOf:

&nbsp;     - type: object

&nbsp;       properties:

&nbsp;         commitment:

&nbsp;           $ref: '#/components/schemas/Commitment'

&nbsp;     - $ref: '#/components/schemas/RateOptions'

&nbsp;   RateOptions:

&nbsp;     type: object

&nbsp;     description: Options used to determine the rate

&nbsp;     properties:

&nbsp;       totalPrice:

&nbsp;         type: number

&nbsp;         description: |

&nbsp;           The total price, including the `totalBasePrice` and all extra service prices.



&nbsp;           Note: This field is only returned when `extraServices` are passed in the request.

&nbsp;         format: double

&nbsp;         example: 3.35

&nbsp;       totalBasePrice:

&nbsp;         type: number

&nbsp;         description: "The price of the rate, fees, and pound postage."

&nbsp;         format: double

&nbsp;         example: 0.63

&nbsp;       rates:

&nbsp;         description: List of available rates for the package including base postage and extra service fees

&nbsp;         type: array

&nbsp;         xml:

&nbsp;           wrapped: true

&nbsp;         items:

&nbsp;           type: object

&nbsp;           properties:

&nbsp;             description:

&nbsp;               type: string

&nbsp;               description: The description of the price.

&nbsp;             startDate:

&nbsp;               type: string

&nbsp;               description: Effective start date of the rate.

&nbsp;               format: date

&nbsp;               example: "2021-07-16"

&nbsp;             endDate:

&nbsp;               description: Effective end date of the rate. If blank, the rate does not have an end date as of yet.

&nbsp;               type: string

&nbsp;               example: "2021-07-16"

&nbsp;               pattern: '^$|^\[0-9]{4}-\[0-9]{2}-\[0-9]{2}$'

&nbsp;             SKU:

&nbsp;               type: string

&nbsp;               description: Pricing SKU.

&nbsp;             price:

&nbsp;               type: number

&nbsp;               description: "Amount of Postage Required, does not include insurance or other extra service fees."

&nbsp;               format: double

&nbsp;             zone:

&nbsp;               type: string

&nbsp;               description: |

&nbsp;                 For domestic requests: indicates the calculated zone between the provided `originZIPCode` and `destinationZIPCode` for a given `mailClass`, `mailingDate`, and `weight`.

&nbsp;                 

&nbsp;                 For international requests: indicates the price group for a given `destinationCountryCode`, `mailClass`, `mailingDate`, and `rateIndicator`.

&nbsp;             weight:

&nbsp;               type: number

&nbsp;               description: "The package weight, in weightUOM. Items must weigh 70 pounds (1120 ounces) or less."

&nbsp;             dimWeight:

&nbsp;               type: number

&nbsp;               description: "The dimensional weight of the package, if greater than specified in weight, in ounces."

&nbsp;             dimensionalWeight:

&nbsp;               type: number

&nbsp;               description: "The dimensional weight of package, if greater than specified in weight, in ounces. This will be removed in July 2025."

&nbsp;               deprecated: true

&nbsp;             priceType:

&nbsp;               $ref: "#/components/schemas/PriceType"

&nbsp;             fees:

&nbsp;               type: array

&nbsp;               description: Fees associated to the package.

&nbsp;               items:

&nbsp;                 type: object

&nbsp;                 properties:

&nbsp;                   name:

&nbsp;                     type: string

&nbsp;                     description: Name of the fee.

&nbsp;                   SKU:

&nbsp;                     type: string

&nbsp;                     description: Pricing SKU.

&nbsp;                   price:

&nbsp;                     type: number

&nbsp;                     description: The price for the fee.

&nbsp;                     format: double

&nbsp;               xml:

&nbsp;                 wrapped: true

&nbsp;             productName:

&nbsp;               type: string

&nbsp;               description: A business friendly name associated to the product that can be displayed to a customer on a shipping portal.

&nbsp;             productDefinition:

&nbsp;               type: string

&nbsp;               description: A business friendly description associated to the product that can be displayed to a customer on a shipping portal.

&nbsp;             processingCategory:

&nbsp;               type: string

&nbsp;               description: |

&nbsp;                 Processing category for the provided rate, this value can be used in the labels API to ensure the provided rate is applied.



&nbsp;                 \* `CARDS` - Cards, translates to PTR code `0`

&nbsp;                 \* `LETTERS` - Letters, translates to PTR code `1`

&nbsp;                 \* `FLATS` - Flats, translates to PTR code `2`

&nbsp;                 \* `MACHINABLE` - Machinable Parcel, translates to PTR code `3`

&nbsp;                 \* `IRREGULAR` - Irregular Parcel, translates to PTR code `4` - This option is deprecated in favor of `NONSTANDARD` and will no longer be returned as of 01/19/2025.

&nbsp;                 \* `NON\_MACHINABLE` - Non-machinable parcel, translates to PTR code `5` - This option is deprecated in favor of `NONSTANDARD` and will no longer be returned as of 01/19/2025.

&nbsp;                 \* `NONSTANDARD` - Nonstandard parcel, translates to PTR code `5`

&nbsp;                 \* `CATALOGS` - Catalogs, translates to PTR code `C`

&nbsp;                 \* `OPEN\_AND\_DISTRIBUTE` - Open and Distribute, translates to PTR code `O`

&nbsp;                 \* `RETURNS` - Returns, translates to PTR code `R`

&nbsp;                 \* `SOFT\_PACK\_MACHINABLE` - Soft Pack Machinable, translates to PTR code `S`

&nbsp;                 \* `SOFT\_PACK\_NON\_MACHINABLE` - Soft Package Non-machinable, translates to PTR code `T`



&nbsp;               enum:

&nbsp;                 - CARDS

&nbsp;                 - LETTERS

&nbsp;                 - FLATS

&nbsp;                 - MACHINABLE

&nbsp;                 - IRREGULAR

&nbsp;                 - NON\_MACHINABLE

&nbsp;                 - NONSTANDARD

&nbsp;                 - CATALOGS

&nbsp;                 - OPEN\_AND\_DISTRIBUTE

&nbsp;                 - RETURNS

&nbsp;                 - SOFT\_PACK\_MACHINABLE

&nbsp;                 - SOFT\_PACK\_NON\_MACHINABLE

&nbsp;               example: NONSTANDARD

&nbsp;             rateIndicator:

&nbsp;               type: string

&nbsp;               description: Two-digit rate indicator code for the provided rate, this value can be used in the labels API to ensure the provided rate is applied.

&nbsp;               example: "SP"

&nbsp;             destinationEntryFacilityType:

&nbsp;               type: string

&nbsp;               description: |

&nbsp;                 Destination Entry Facility type for the provided rate, this value can be used in the labels API to ensure the provided rate is applied.



&nbsp;                 \* `NONE` - None, translates to PTR code `N`

&nbsp;                 \* `AREA\_DISTRIBUTION\_CENTER` - Area Distribution Center, translates to PTR code `A`

&nbsp;                 \* `AUXILIARY\_SERVICE\_FACILITY` - Auxiliary Service Facility, translates to PTR code `F`

&nbsp;                 \* `DESTINATION\_DELIVERY\_UNIT` - Destination Delivery Unit, translates to PTR code `D`

&nbsp;                 \* `DESTINATION\_NETWORK\_DISTRIBUTION\_CENTER` - Destination Network Distribution Center, translates to PTR code `B`

&nbsp;                 \* `DESTINATION\_SECTIONAL\_CENTER\_FACILITY` - Destination Sectional Center Facility, translates to PTR code `S`

&nbsp;                 \* `DESTINATION\_SERVICE\_HUB` - Destination Service Hub, translates to PTR code `H`

&nbsp;                 \* `INTERNATIONAL\_SERVICE\_CENTER` - International Service Center, translates to PTR code `I`

&nbsp;                 \* `DESTINATION\_REGIONAL\_PROCESSING\_DISTRIBUTION\_CENTER` - Destination Regional Processing Distribution Center, translates to PTR code `B`

&nbsp;                 

&nbsp;                 Note:

&nbsp;                 \* Effective 01/18/2026: `DESTINATION\_NETWORK\_DISTRIBUTION\_CENTER` with `PARCEL\_SELECT` is no longer eligible.

&nbsp;                 \* Effective 01/18/2026: (NSA Only) `DESTINATION\_REGIONAL\_PROCESSING\_DISTRIBUTION\_CENTER` with `PARCEL\_SELECT` is available as an option.

&nbsp;               enum:

&nbsp;                 - NONE

&nbsp;                 - AREA\_DISTRIBUTION\_CENTER

&nbsp;                 - AUXILIARY\_SERVICE\_FACILITY

&nbsp;                 - DESTINATION\_DELIVERY\_UNIT

&nbsp;                 - DESTINATION\_NETWORK\_DISTRIBUTION\_CENTER

&nbsp;                 - DESTINATION\_SECTIONAL\_CENTER\_FACILITY

&nbsp;                 - DESTINATION\_SERVICE\_HUB

&nbsp;                 - INTERNATIONAL\_SERVICE\_CENTER

&nbsp;                 - DESTINATION\_REGIONAL\_PROCESSING\_DISTRIBUTION\_CENTER

&nbsp;               example: NONE

&nbsp;             mailClass:

&nbsp;               $ref: "#/components/schemas/AllMailClasses"

&nbsp;           additionalProperties: false

&nbsp;           xml:

&nbsp;             name: rate

&nbsp;             wrapped: true

&nbsp;       extraServices:

&nbsp;         type: array

&nbsp;         description: Extra services requested on the package.

&nbsp;         xml:

&nbsp;           name: extraServices

&nbsp;           wrapped: true

&nbsp;         items:

&nbsp;           type: object

&nbsp;           properties:

&nbsp;             name:

&nbsp;               type: string

&nbsp;               description: Name of the extra service.

&nbsp;             SKU:

&nbsp;               type: string

&nbsp;               description: SKU of the extra service.

&nbsp;             price:

&nbsp;               type: number

&nbsp;               description: The price for the extra service.

&nbsp;               format: double

&nbsp;             extraService:

&nbsp;               type: string

&nbsp;               description: The code for the extra service.

&nbsp;               example: "957"

&nbsp;             priceType:

&nbsp;               $ref: "#/components/schemas/PriceType"

&nbsp;             warnings:

&nbsp;               type: array

&nbsp;               description: List of warnings

&nbsp;               xml:

&nbsp;                 wrapped: true

&nbsp;               items:

&nbsp;                 type: object

&nbsp;                 properties:

&nbsp;                   warningCode:

&nbsp;                     type: string

&nbsp;                     description: Warning code in response to the request.

&nbsp;                     example: "001"

&nbsp;                   warningDescription:

&nbsp;                     type: string

&nbsp;                     description: A human-readable message describing the warning.

&nbsp;                     example: Contract rate not found for request. Published rate returned.

&nbsp;           additionalProperties: false

&nbsp;     additionalProperties: true

&nbsp;   DomesticPackageDescription:

&nbsp;     description: Details of package being shipped

&nbsp;     allOf:

&nbsp;     - $ref: '#/components/schemas/ShippingOptionsPackageDescription'

&nbsp;     - required:

&nbsp;       - mailClass

&nbsp;       type: object

&nbsp;       properties:

&nbsp;         mailClass:

&nbsp;           type: string

&nbsp;           description: |

&nbsp;             Mail classes for the label.



&nbsp;             Note:

&nbsp;             - `PARCEL\_SELECT\_LIGHTWEIGHT` is deprecated and will convert to `PARCEL\_SELECT`

&nbsp;             - `FIRST-CLASS\_PACKAGE\_SERVICE` is deprecated and will convert to `USPS\_GROUND\_ADVANTAGE`

&nbsp;             - `ALL` is deprecated and will convert to `ALL\_OUTBOUND`

&nbsp;           enum:

&nbsp;           - PARCEL\_SELECT

&nbsp;           - PARCEL\_SELECT\_LIGHTWEIGHT

&nbsp;           - USPS\_CONNECT\_LOCAL

&nbsp;           - USPS\_CONNECT\_REGIONAL

&nbsp;           - USPS\_CONNECT\_MAIL

&nbsp;           - USPS\_GROUND\_ADVANTAGE

&nbsp;           - USPS\_GROUND\_ADVANTAGE\_RETURN\_SERVICE

&nbsp;           - PRIORITY\_MAIL\_EXPRESS

&nbsp;           - PRIORITY\_MAIL\_EXPRESS\_RETURN\_SERVICE

&nbsp;           - PRIORITY\_MAIL

&nbsp;           - PRIORITY\_MAIL\_RETURN\_SERVICE

&nbsp;           - FIRST-CLASS\_PACKAGE\_SERVICE

&nbsp;           - LIBRARY\_MAIL

&nbsp;           - MEDIA\_MAIL

&nbsp;           - BOUND\_PRINTED\_MATTER

&nbsp;           - ALL

&nbsp;           - ALL\_OUTBOUND

&nbsp;           - ALL\_RETURNS

&nbsp;         extraServices:

&nbsp;           maxItems: 5

&nbsp;           minItems: 0

&nbsp;           type: array

&nbsp;           description: |         

&nbsp;             Extra Services requested on the package. The available options are:

&nbsp;             \* 365 - Global Direct Entry

&nbsp;             \* 415 - USPS Label Delivery

&nbsp;             \* 452 - USPS Returns

&nbsp;             \* 480 - Tracking Plus 6 Months

&nbsp;             \* 481 - Tracking Plus 1 Year

&nbsp;             \* 482 - Tracking Plus 3 Years

&nbsp;             \* 483 - Tracking Plus 5 Years

&nbsp;             \* 484 - Tracking Plus 7 Years

&nbsp;             \* 485 - Tracking Plus 10 Years

&nbsp;             \* 486 - Tracking Plus Signature 3 Years

&nbsp;             \* 487 - Tracking Plus Signature 5 Years

&nbsp;             \* 488 - Tracking Plus Signature 7 Years

&nbsp;             \* 489 - Tracking Plus Signature 10 Years

&nbsp;             \* 498 - PO Box Locker – Stocking Fee (NSA Only)

&nbsp;             \* 500 - PO Box Locker – Self-Service Pickup Fee (NSA Only)

&nbsp;             \* 501 - PO Box Locker – Clerk-Assisted Pickup Fee (NSA Only)

&nbsp;             \* 502 - PO Box Locker – Local Delivery Fee (NSA Only)

&nbsp;             \* 810 - HAZMAT Air Eligible Ethanol Package

&nbsp;             \* 811 - HAZMAT Class 1 - Toy Propellant/Safety Fuse Package

&nbsp;             \* 812 - HAZMAT Class 3 – Flammable Liquid Package

&nbsp;             \* 813 - HAZMAT Class 7 - Radioactive Materials Package

&nbsp;             \* 814 - HAZMAT Class 8 - Corrosive Materials Package

&nbsp;             \* 815 - HAZMAT Class 8 - Nonspillable Wet Battery Package

&nbsp;             \* 816 - HAZMAT Class 9 - Lithium Battery Marked - Ground Only Package

&nbsp;             \* 817 - HAZMAT Class 9 - Lithium Battery - Returns Package

&nbsp;             \* 818 - HAZMAT Class 9 - Lithium batteries, marked package

&nbsp;             \* 819 - HAZMAT Class 9 - Dry Ice Package

&nbsp;             \* 820 - HAZMAT Class 9 - Lithium batteries, unmarked package

&nbsp;             \* 821 - HAZMAT Class 9 - Magnetized Materials Package

&nbsp;             \* 822 - HAZMAT Division 4.1 – Flammable Solids or Safety Matches Package

&nbsp;             \* 823 - HAZMAT Division 5.1 - Oxidizers Package

&nbsp;             \* 824 - HAZMAT Division 5.2 - Organic Peroxides Package

&nbsp;             \* 825 - HAZMAT Division 6.1 – Toxic Materials Package

&nbsp;             \* 826 - HAZMAT Division 6.2 – Infectious Substances Package

&nbsp;             \* 827 - HAZMAT Excepted Quantity Provision Package

&nbsp;             \* 828 - HAZMAT Ground Only

&nbsp;             \* 829 - HAZMAT ID8000 Consumer Commodity Package

&nbsp;             \* 830 - HAZMAT Lighters Package

&nbsp;             \* 831 - HAZMAT LTD QTY Ground Package

&nbsp;             \* 832 - HAZMAT Small Quantity Provision Package

&nbsp;             \* 853 - Perishable Material

&nbsp;             \* 856 - Live Animals Transportation Fee

&nbsp;             \* 857 - Hazardous Material

&nbsp;             \* 858 - Cremated Remains

&nbsp;             \* 910 - Certified Mail

&nbsp;             \* 911 - Certified Mail Restricted Delivery

&nbsp;             \* 912 - Certified Mail Adult Signature Required

&nbsp;             \* 913 - Certified Mail Adult Signature Restricted Delivery

&nbsp;             \* 915 - Collect on Delivery (COD)

&nbsp;             \* 917 - COD Restricted Delivery

&nbsp;             \* 920 - USPS Tracking

&nbsp;             \* 921 - Signature Confirmation

&nbsp;             \* 922 - Adult Signature Required 21 or Over

&nbsp;             \* 923 - Adult Signature Restricted Delivery 21 or Over

&nbsp;             \* 924 - Signature Confirmation Restricted Delivery

&nbsp;             \* 925 - Priority Mail Express Merchandise Insurance

&nbsp;             \* 930 - Insurance <= $500

&nbsp;             \* 931 - Insurance > $500

&nbsp;             \* 934 - Insurance Restricted Delivery

&nbsp;             \* 940 - Registered Mail

&nbsp;             \* 941 - Registered Mail Restricted Delivery

&nbsp;             \* 955 - Return Receipt

&nbsp;             \* 957 - Return Receipt Electronic

&nbsp;             \* 972 - Live Animal and Perishable Handling Fee

&nbsp;             \* 981 - Signature Requested (PRIORITY\_MAIL\_EXPRESS only)

&nbsp;             \* 984 - Parcel Locker Delivery

&nbsp;             \* 986 - PO to Addressee (PRIORITY\_MAIL\_EXPRESS only)

&nbsp;             \* 991 - Sunday Delivery

&nbsp;           xml:

&nbsp;             name: extraServices

&nbsp;             wrapped: true

&nbsp;           items:

&nbsp;             $ref: '#/components/schemas/ExtraService'

&nbsp;         packageValue:

&nbsp;           minimum: 0

&nbsp;           type: number

&nbsp;           description: "The merchandise value of the package, in US dollars. Required to receive prices for Insurance and Collect On Delivery extra services.  The price of Insurance, Collect On Delivery, and Registered Mail extra services will vary based on the `packageValue` requested."

&nbsp;           example: 35

&nbsp;         mailingDate:

&nbsp;           description: "The date on which the package will be mailed. If the time is not provided, it will be defaulted to 6:00 p.m."

&nbsp;           type: string

&nbsp;           oneOf:

&nbsp;           - $ref: '#/components/schemas/MailingDate'

&nbsp;           - $ref: '#/components/schemas/MailingDateTime'

&nbsp;       additionalProperties: true

&nbsp;       description: "Package characteristics used to price the shipment including requested mail class, weight, dimensions, and more."

&nbsp;   InternationalPackageDescription:

&nbsp;     description: Details of package being shipped

&nbsp;     allOf:

&nbsp;     - $ref: '#/components/schemas/ShippingOptionsPackageDescription'

&nbsp;     - required:

&nbsp;       - mailClass

&nbsp;       type: object

&nbsp;       properties:

&nbsp;         mailClass:

&nbsp;           type: string

&nbsp;           description: |

&nbsp;             International Mail classes for the label.



&nbsp;             `GLOBAL\_EXPRESS\_GUARANTEED` is supported by shipping options, but is not supported by labels. Global Express Guaranteed Service is suspended as of September 29, 2024.

&nbsp;           enum:

&nbsp;           - FIRST-CLASS\_PACKAGE\_INTERNATIONAL\_SERVICE

&nbsp;           - PRIORITY\_MAIL\_INTERNATIONAL

&nbsp;           - PRIORITY\_MAIL\_EXPRESS\_INTERNATIONAL

&nbsp;           - GLOBAL\_EXPRESS\_GUARANTEED

&nbsp;           - ALL

&nbsp;         extraServices:

&nbsp;           maxItems: 5

&nbsp;           minItems: 0

&nbsp;           type: array

&nbsp;           description: |

&nbsp;             Extra Services requested on the package. The available options are:

&nbsp;             \* 370 - USPS Delivery Duties Paid Fee

&nbsp;             \* 813 - HAZMAT Class 7 - Radioactive Materials Package

&nbsp;             \* 820 - HAZMAT Class 9 - Lithium batteries, unmarked package

&nbsp;             \* 826 - HAZMAT Division 6.2 – Infectious Substances Package

&nbsp;             \* 857 - Hazardous Material          

&nbsp;             \* 930 - Insurance <= $500

&nbsp;             \* 931 - Insurance > $500

&nbsp;             \* 955 - Return Receipt (Unsupported as of 01/19/2025)

&nbsp;           xml:

&nbsp;             name: extraServices

&nbsp;             wrapped: true

&nbsp;           items:

&nbsp;             $ref: '#/components/schemas/InternationalExtraService'

&nbsp;         packageValue:

&nbsp;           minimum: 0

&nbsp;           type: number

&nbsp;           description: "The merchandise value of the package, in US dollars. Required to receive prices for Insurance.  The price of the Insurance extra service will vary based on the `packageValue` requested."

&nbsp;           example: 35

&nbsp;         mailingDate:

&nbsp;           type: string

&nbsp;           description: "Supports either a date or date-time entry, if using a date the time will be defaulted to 6:00 pm local time for the purpose of Service Delivery Standard estimates. A mailing date of 0-30 days in advance can be requested. "

&nbsp;           oneOf:

&nbsp;           - $ref: '#/components/schemas/MailingDate'

&nbsp;           - $ref: '#/components/schemas/MailingDateTime'

&nbsp;       additionalProperties: true

&nbsp;       description: "Package characteristics used to price the shipment including requested mail class, weight, dimensions, and more."

&nbsp;   DutiesTaxesFeesQuote:

&nbsp;     title: Duties, taxes, and fees details.

&nbsp;     type: object

&nbsp;     description: "The duties, taxes, and fees details. Included if `requestDutiesTaxesFees` is `true` and the shipping destination has applicable duties, taxes, and fees."

&nbsp;     properties:

&nbsp;       packageFee:

&nbsp;         type: number

&nbsp;         format: float

&nbsp;         description: "The value of the total landed cost fee associated with the package."

&nbsp;       itemQuotes:

&nbsp;         type: array

&nbsp;         description: "The total landed cost prices for taxes and duties on each item."

&nbsp;         items:

&nbsp;           type: object

&nbsp;           properties:

&nbsp;             dutyPrice:

&nbsp;               type: number

&nbsp;               format: float

&nbsp;               description: "The value of the duties associated with the item."

&nbsp;             taxPrice:

&nbsp;               type: number

&nbsp;               format: float

&nbsp;               description: "The value of the taxes associated with the item."

&nbsp;             itemId:

&nbsp;               type: string

&nbsp;               description: "The corresponding `itemId` provided in the request."

&nbsp;   ExtraService:

&nbsp;     title: Extra Service Codes

&nbsp;     type: integer

&nbsp;     description: Available extra service codes.

&nbsp;     enum:

&nbsp;     - 365

&nbsp;     - 415

&nbsp;     - 452

&nbsp;     - 480

&nbsp;     - 481

&nbsp;     - 482

&nbsp;     - 483

&nbsp;     - 484

&nbsp;     - 485

&nbsp;     - 486

&nbsp;     - 487

&nbsp;     - 488

&nbsp;     - 489

&nbsp;     - 498

&nbsp;     - 500

&nbsp;     - 501

&nbsp;     - 502

&nbsp;     - 810

&nbsp;     - 811

&nbsp;     - 812

&nbsp;     - 813

&nbsp;     - 814

&nbsp;     - 815

&nbsp;     - 816

&nbsp;     - 817

&nbsp;     - 818

&nbsp;     - 819

&nbsp;     - 820

&nbsp;     - 821

&nbsp;     - 822

&nbsp;     - 823

&nbsp;     - 824

&nbsp;     - 825

&nbsp;     - 826

&nbsp;     - 827

&nbsp;     - 828

&nbsp;     - 829

&nbsp;     - 830

&nbsp;     - 831

&nbsp;     - 832

&nbsp;     - 853

&nbsp;     - 856

&nbsp;     - 857

&nbsp;     - 858

&nbsp;     - 910

&nbsp;     - 911

&nbsp;     - 912

&nbsp;     - 913

&nbsp;     - 915

&nbsp;     - 917

&nbsp;     - 920

&nbsp;     - 921

&nbsp;     - 922

&nbsp;     - 923

&nbsp;     - 924

&nbsp;     - 925

&nbsp;     - 930

&nbsp;     - 931

&nbsp;     - 934

&nbsp;     - 940

&nbsp;     - 941

&nbsp;     - 955

&nbsp;     - 957

&nbsp;     - 972

&nbsp;     - 981

&nbsp;     - 984

&nbsp;     - 986

&nbsp;     - 991

&nbsp;   InternationalExtraService:

&nbsp;     title: Extra Service Codes

&nbsp;     type: integer

&nbsp;     description: |

&nbsp;       Extra Services requested on the package. The available options are:

&nbsp;       \* 370 - USPS Delivery Duties Paid Fee

&nbsp;       \* 813 - HAZMAT Class 7 - Radioactive Materials Package

&nbsp;       \* 820 - HAZMAT Class 9 - Lithium batteries, unmarked package

&nbsp;       \* 826 - HAZMAT Division 6.2 – Infectious Substances Package

&nbsp;       \* 857 - Hazardous Material

&nbsp;       \* 930 - Insurance <= $500

&nbsp;       \* 931 - Insurance > $500

&nbsp;       \* 955 - Return Receipt (Unsupported as of 01/19/2025)

&nbsp;     enum:

&nbsp;       - 370

&nbsp;       - 813

&nbsp;       - 820

&nbsp;       - 826

&nbsp;       - 857

&nbsp;       - 930

&nbsp;       - 931

&nbsp;       - 955

&nbsp;   Commitment:

&nbsp;     title: Commitment

&nbsp;     type: object

&nbsp;     properties:

&nbsp;       name:

&nbsp;         type: string

&nbsp;         description: "Commitment name such as 1 Day, 2 Days, 3 Days, MILITARY, DPO, NO STD, or UNAVAILABLE."

&nbsp;       scheduleDeliveryDate:

&nbsp;         type: string

&nbsp;         description: |

&nbsp;           Date USPS expects that the package or mailpiece will be delivered based on the origin, destination, and drop-off time and date in the request. Actual delivery date may vary based on when the package or mailpiece is entered or other conditions.

&nbsp;           

&nbsp;           Note: This field has been deprecated in favor of `expectedDeliveryDate `and will be removed in a future release. Please transition to using `expectedDeliveryDate`.

&nbsp;         format: date

&nbsp;         deprecated: true

&nbsp;       expectedDeliveryDate:

&nbsp;         type: string

&nbsp;         description: Date in the YYYY-MM-DD format.

&nbsp;       guaranteedDelivery:

&nbsp;         type: boolean

&nbsp;         description: "If true, the expectedDeliveryDate is guaranteed."

&nbsp;       isPriorityMailNextDay:

&nbsp;         type: boolean

&nbsp;         description: "Indicates if the commitment is for Priority Mail Next Day service."

&nbsp;     additionalProperties: true

&nbsp;     description: The commitment and the scheduled delivery date of the package.

&nbsp;   DomesticPricingOption:

&nbsp;     description: The option for domestic pricing

&nbsp;     type: object

&nbsp;     properties:

&nbsp;       shippingOptions:

&nbsp;         description: List of available shipping options and delivery options for the package

&nbsp;         type: array

&nbsp;         readOnly: true

&nbsp;         xml:

&nbsp;           wrapped: true

&nbsp;         items:

&nbsp;           $ref: '#/components/schemas/DomesticOptions'

&nbsp;       priceType:

&nbsp;         $ref: '#/components/schemas/PriceTypeRequest'

&nbsp;       paymentAccount:

&nbsp;         description: The total amount to be charged for the shipment

&nbsp;         allOf:

&nbsp;           - $ref: '#/components/schemas/PaymentAccount'

&nbsp;           - type: object

&nbsp;             properties:

&nbsp;               CRID:

&nbsp;                 type: string

&nbsp;                 description: Customer Registration ID (CRID) associated with the business or mailer. Used to retrieve any contract-specific service standards.

&nbsp;                 example: "12345678"

&nbsp;             additionalProperties: true

&nbsp;     additionalProperties: false

&nbsp;     xml:

&nbsp;       name: pricingOption

&nbsp;   InternationalPricingOption:

&nbsp;     type: object

&nbsp;     description: Option for international pricing

&nbsp;     properties:

&nbsp;       shippingOptions:

&nbsp;         description: List of available shipping services and delivery options for the package

&nbsp;         type: array

&nbsp;         readOnly: true

&nbsp;         xml:

&nbsp;           wrapped: true

&nbsp;         items:

&nbsp;           $ref: '#/components/schemas/InternationalOptions'

&nbsp;       priceType:

&nbsp;        $ref: '#/components/schemas/PriceTypeRequest'

&nbsp;       paymentAccount:

&nbsp;         $ref: '#/components/schemas/PaymentAccount'

&nbsp;     additionalProperties: false

&nbsp;     xml:

&nbsp;       name: pricingOption

&nbsp;   PaymentAccount:

&nbsp;     title: Payment Account

&nbsp;     type: object

&nbsp;     properties:

&nbsp;       accountType:

&nbsp;         type: string

&nbsp;         description: |

&nbsp;           The type of payment account.

&nbsp;           

&nbsp;           Note:

&nbsp;           - `EPS`, `PERMIT`, and `METER` are only available for Outbound Mail Classes. 

&nbsp;           - `METER` is only available to PC Postage Providers.  

&nbsp;           - `MID` is only available for Return Mail Classes.

&nbsp;         example: EPS

&nbsp;         enum:

&nbsp;         - EPS

&nbsp;         - PERMIT

&nbsp;         - METER

&nbsp;         - MID

&nbsp;       accountNumber:

&nbsp;         type: string

&nbsp;         description: "The Enterprise Payment Account, Permit number, Mailer ID (MID), or PC Postage meter number associated with a contract."

&nbsp;     additionalProperties: true

&nbsp;     description: Payment account information. Used only if `priceType` is `CONTRACT`.

&nbsp;   PriceTypeRequest:

&nbsp;     title: Price Type

&nbsp;     type: string

&nbsp;     description: |

&nbsp;       Price type of the Shipping Request.



&nbsp;       Note: 

&nbsp;       - If `priceType` is `CONTRACT`, `paymentAccount` is required.

&nbsp;     default: COMMERCIAL

&nbsp;     enum:

&nbsp;       - RETAIL

&nbsp;       - COMMERCIAL

&nbsp;       - CONTRACT

&nbsp;   ErrorMessage:

&nbsp;     title: Error

&nbsp;     type: object

&nbsp;     properties:

&nbsp;       apiVersion:

&nbsp;         type: string

&nbsp;         description: The version of the API that was used and that raised the error.

&nbsp;       error:

&nbsp;         type: object

&nbsp;         properties:

&nbsp;           code:

&nbsp;             type: string

&nbsp;             description: The error status code that has been returned in response to the request.

&nbsp;           message:

&nbsp;             type: string

&nbsp;             description: A human-readable message describing the error.

&nbsp;           errors:

&nbsp;             type: array

&nbsp;             description: List of errors

&nbsp;             items:

&nbsp;               type: object

&nbsp;               properties:

&nbsp;                 status:

&nbsp;                   type: string

&nbsp;                   description: The status code response returned to the client.

&nbsp;                 code:

&nbsp;                   type: string

&nbsp;                   description: An internal subordinate code used for error diagnosis.

&nbsp;                 title:

&nbsp;                   type: string

&nbsp;                   description: A human-readable title that identifies the error.

&nbsp;                 detail:

&nbsp;                   type: string

&nbsp;                   description: A human-readable description of the error that occurred.

&nbsp;                 source:

&nbsp;                   type: object

&nbsp;                   properties:

&nbsp;                     parameter:

&nbsp;                       type: string

&nbsp;                       description: The input in the request which caused an error.

&nbsp;                     example:

&nbsp;                       type: string

&nbsp;                       description: An example of a valid value for the input parameter.

&nbsp;                   additionalProperties: true

&nbsp;                   description: The element that is suspected of originating the error.  Helps to pinpoint the problem.

&nbsp;               additionalProperties: true

&nbsp;         additionalProperties: true

&nbsp;         description: The high-level error that has occurred as indicated by the status code.

&nbsp;     additionalProperties: true

&nbsp;     description: Standard error message response.

&nbsp;   originZIPCode:

&nbsp;     pattern: "^\\\\d{5}(?:\[-\\\\s]\\\\d{4})?$"

&nbsp;     type: string

&nbsp;     description: The originating ZIP code for the package.

&nbsp;   destinationZIPCode:

&nbsp;     pattern: "^\\\\d{5}(?:\[-\\\\s]\\\\d{4})?$"

&nbsp;     type: string

&nbsp;     description: The destination ZIP code for the package.

&nbsp;   postalCode:

&nbsp;     maxLength: 11

&nbsp;     type: string

&nbsp;     description: This is the Postal Code used in an international addresses.

&nbsp;   ShippingOptionsPackageDescription:

&nbsp;     title: Package Description

&nbsp;     type: object

&nbsp;     required:

&nbsp;       - height

&nbsp;       - length

&nbsp;       - weight

&nbsp;       - width

&nbsp;     properties:

&nbsp;       weight:

&nbsp;         minimum: 0

&nbsp;         exclusiveMinimum: true

&nbsp;         type: number

&nbsp;         description: "The package weight, in weightUOM (Unit Of Measure). Items must weigh 70 pounds (1120 ounces) or less."

&nbsp;       length:

&nbsp;         minimum: 0

&nbsp;         exclusiveMinimum: true

&nbsp;         type: number

&nbsp;         description: "The length of the container, in dimensionsUOM. If partial dimensions are provided, an error response will return. Length, Width, Height are required for accurate pricing of a rectangular package when any dimension of the item exceeds 12 inches. In addition, Girth is required only for a non- rectangular package in addition to Length, Width, Height when any dimension of the package exceeds 12 inches. For rectangular packages, the Girth dimension must be left blank as this dimension is to only be used for non- rectangular packages."

&nbsp;       height:

&nbsp;         minimum: 0

&nbsp;         exclusiveMinimum: true

&nbsp;         type: number

&nbsp;         description: "The height of the container, in dimensionsUOM. If partial dimensions are provided, an error response will return. Length, Width, Height are required for accurate pricing of a rectangular package when any dimension of the item exceeds 12 inches. In addition, Girth is required only for a non- rectangular package in addition to Length, Width, Height when any dimension of the package exceeds 12 inches. For rectangular packages, the Girth dimension must be left blank as this dimension is to only be used for non- rectangular packages."

&nbsp;       width:

&nbsp;         minimum: 0

&nbsp;         exclusiveMinimum: true

&nbsp;         type: number

&nbsp;         description: "The width of the container, in dimensionsUOM. If partial dimensions are provided, an error response will return. Length, Width, Height are required for accurate pricing of a rectangular package when any dimension of the item exceeds 12 inches. In addition, Girth is required only for a non- rectangular package in addition to Length, Width, Height when any dimension of the package exceeds 12 inches. For rectangular packages, the Girth dimension must be left blank as this dimension is to only be used for non- rectangular packages."

&nbsp;       girth:

&nbsp;         minimum: 0

&nbsp;         exclusiveMinimum: true

&nbsp;         type: number

&nbsp;         description: "The girth of the container, in dimensionsUOM. If partial dimensions are provided, an error response will return. Length, Width, Height are required for accurate pricing of a rectangular package when any dimension of the item exceeds 12 inches. In addition, Girth is required only for a non- rectangular package in addition to Length, Width, Height when any dimension of the package exceeds 12 inches. For rectangular packages, the Girth dimension must be left blank as this dimension is to only be used for non- rectangular packages."

&nbsp;       hasNonstandardCharacteristics:

&nbsp;         default: false

&nbsp;         type: boolean

&nbsp;         description: "Package is nonstandard. Nonstandard packages include cylindrical tubes and rolls, certain high-density items, cartons containing more than 24 ounces of liquids in one or more glass containers, cartons containing 1 gallon or more of liquid in metal or plastic containers, and items in \[201.7.6.2](https://pe.usps.com/text/dmm300/201.htm#7.6.2)."

&nbsp;     additionalProperties: true

&nbsp;     description: Package Definitions

&nbsp;   MailingDate:

&nbsp;     type: string

&nbsp;     description: "The date package will be mailed. The mailing date may be today plus 0 to 30 days in advance. Enter the date in the full-date notation as defined by \[RFC 3339, section 5.6](https://datatracker.ietf.org/doc/html/rfc3339#section-5.6)."

&nbsp;     format: date

&nbsp;   MailingDateTime:

&nbsp;     type: string

&nbsp;     description: "The date and time a package will be mailed. The mailing date may be today plus 0 to 30 days in advance. Enter the date in the date-time notation as defined by \[RFC 3339, section 5.6](https://datatracker.ietf.org/doc/html/rfc3339#section-5.6)."

&nbsp;     format: date-time

&nbsp;   DomesticMailClass:

&nbsp;     type: string

&nbsp;     description: |

&nbsp;       The domestic mail service requested.

&nbsp;     enum:

&nbsp;       - PARCEL\_SELECT

&nbsp;       - USPS\_CONNECT\_LOCAL

&nbsp;       - USPS\_CONNECT\_REGIONAL

&nbsp;       - USPS\_CONNECT\_MAIL

&nbsp;       - USPS\_GROUND\_ADVANTAGE

&nbsp;       - USPS\_GROUND\_ADVANTAGE\_RETURN\_SERVICE

&nbsp;       - PRIORITY\_MAIL\_EXPRESS

&nbsp;       - PRIORITY\_MAIL\_EXPRESS\_RETURN\_SERVICE

&nbsp;       - PRIORITY\_MAIL

&nbsp;       - PRIORITY\_MAIL\_RETURN\_SERVICE

&nbsp;       - LIBRARY\_MAIL

&nbsp;       - MEDIA\_MAIL

&nbsp;       - BOUND\_PRINTED\_MATTER

&nbsp;     example: PARCEL\_SELECT

&nbsp;   InternationalMailClass:

&nbsp;     type: string

&nbsp;     description: |

&nbsp;       The international mail service requested.



&nbsp;       Note:

&nbsp;       - `GLOBAL\_EXPRESS\_GUARANTEED` - Global Express Guaranteed Service is suspended as of September 29, 2024.

&nbsp;     enum:

&nbsp;       - FIRST-CLASS\_PACKAGE\_INTERNATIONAL\_SERVICE

&nbsp;       - PRIORITY\_MAIL\_INTERNATIONAL

&nbsp;       - PRIORITY\_MAIL\_EXPRESS\_INTERNATIONAL

&nbsp;       - GLOBAL\_EXPRESS\_GUARANTEED

&nbsp;     example: PRIORITY\_MAIL\_INTERNATIONAL

&nbsp;   AllMailClasses:

&nbsp;     description: List or enumeration of the domestic or international mail classes available

&nbsp;     oneOf:

&nbsp;       - $ref: "#/components/schemas/DomesticMailClass"

&nbsp;       - $ref: "#/components/schemas/InternationalMailClass"

&nbsp;   PriceType:

&nbsp;     type: string

&nbsp;     description: |-

&nbsp;       The type of price applied.

&nbsp;        \* Valid Options for Domestic Prices include: 'RETAIL', 'COMMERCIAL', \& 'CONTRACT'

&nbsp;        \* Valid Options for International Prices include: 'RETAIL', 'COMMERCIAL', 'COMMERCIAL\_BASE', 'COMMERCIAL\_PLUS', \& 'CONTRACT'

&nbsp;     enum:

&nbsp;       - RETAIL

&nbsp;       - COMMERCIAL

&nbsp;       - COMMERCIAL\_BASE

&nbsp;       - COMMERCIAL\_PLUS

&nbsp;       - CONTRACT

&nbsp;     example: "COMMERCIAL"

&nbsp; examples:

&nbsp;   DomesticOutboundOptionsExample:

&nbsp;     summary: Domestic Outbound Options Response

&nbsp;     description: Example response for a Domestic Outbound Options Request

&nbsp;     value:

&nbsp;       originZIPCode: "50311"

&nbsp;       destinationZIPCode: "60119"

&nbsp;       pricingOptions:

&nbsp;         - shippingOptions:

&nbsp;             - mailClass: PARCEL\_SELECT

&nbsp;               rateOptions:

&nbsp;                 - commitment:

&nbsp;                     name: 2 Days

&nbsp;                     scheduleDeliveryDate: "2024-10-04"

&nbsp;                     deprecated: true

&nbsp;                     expectedDeliveryDate: "2024-10-04"

&nbsp;                     guaranteedDelivery: false

&nbsp;                     isPriorityMailNextDay: false

&nbsp;                   totalBasePrice: 9.17

&nbsp;                   rates:

&nbsp;                     - description: Parcel Select Nonstandard DNDC Single-piece

&nbsp;                       startDate: "2024-07-14"

&nbsp;                       endDate: "2024-10-05"

&nbsp;                       price: 6.17

&nbsp;                       zone: "00"

&nbsp;                       weight: 1.0

&nbsp;                       dimensionalWeight: 0.0

&nbsp;                       dimWeight: 0.0

&nbsp;                       fees:

&nbsp;                         - name: Nonstandard Length > 22

&nbsp;                           price: 3.00

&nbsp;                           SKU: D811XVCXXXX0000

&nbsp;                       priceType: COMMERCIAL

&nbsp;                       mailClass: PARCEL\_SELECT

&nbsp;                       productName: ""

&nbsp;                       productDefinition: ""

&nbsp;                       processingCategory: "NONSTANDARD"

&nbsp;                       rateIndicator: "SP"

&nbsp;                       destinationEntryFacilityType: "DESTINATION\_NETWORK\_DISTRIBUTION\_CENTER"

&nbsp;                       SKU: DVXP0XXCXC00010

&nbsp;                   extraServices:

&nbsp;                     - name: Return Receipt Electronic

&nbsp;                       price: 2.62

&nbsp;                       extraService: "957"

&nbsp;                       priceType: COMMERCIAL

&nbsp;                       warnings:

&nbsp;                         - warningCode: "001"

&nbsp;                           warningDescription: "Contract rate not found for request. Published rate returned."

&nbsp;                       SKU: DXRX0EXXXCX0000

&nbsp;           priceType: CONTRACT

&nbsp;           paymentAccount:

&nbsp;             accountType: EPS

&nbsp;             accountNumber: "12345767890"

&nbsp;   DomesticReturnOptionsExample:

&nbsp;     summary: Domestic Returns Options Response

&nbsp;     description: Example response for a Domestic Returns Options Request

&nbsp;     value:

&nbsp;       originZIPCode: "50311"

&nbsp;       destinationZIPCode: "60119"

&nbsp;       pricingOptions:

&nbsp;         - shippingOptions:

&nbsp;             - mailClass: USPS\_GROUND\_ADVANTAGE\_RETURN\_SERVICE

&nbsp;               rateOptions:

&nbsp;                 - totalBasePrice: 4.65

&nbsp;                   rates:

&nbsp;                     - description: USPS Ground Advantage Return Machinable Single-piece

&nbsp;                       startDate: "2025-07-13"

&nbsp;                       endDate: ""

&nbsp;                       price: 4.65

&nbsp;                       zone: "01"

&nbsp;                       weight: 0.50

&nbsp;                       dimensionalWeight: 0.0

&nbsp;                       dimWeight: 0.0

&nbsp;                       priceType: COMMERCIAL

&nbsp;                       mailClass: USPS\_GROUND\_ADVANTAGE\_RETURN\_SERVICE

&nbsp;                       productName: ""

&nbsp;                       productDefinition: ""

&nbsp;                       processingCategory: "NONSTANDARD"

&nbsp;                       rateIndicator: "SP"

&nbsp;                       destinationEntryFacilityType: "NONE"

&nbsp;                       SKU: DUXP0RXXUC01080

&nbsp;                   extraServices: \[]

&nbsp;           priceType: CONTRACT

&nbsp;           paymentAccount:

&nbsp;             accountType: MID

&nbsp;             accountNumber: "123456789"

&nbsp;   InternationalOptionsExample:

&nbsp;     summary: International Options Response

&nbsp;     description: Example response for an International Options Request

&nbsp;     value:

&nbsp;       originZIPCode: "22407"

&nbsp;       foreignPostalCode: "63118"

&nbsp;       destinationCountryCode: CA

&nbsp;       pricingOptions:

&nbsp;         - shippingOptions:

&nbsp;             - mailClass: PRIORITY\_MAIL\_EXPRESS\_INTERNATIONAL

&nbsp;               rateOptions:

&nbsp;                 - totalBasePrice: 65.64

&nbsp;                   rates:

&nbsp;                     - description: Priority Mail Express International ISC Single-piece

&nbsp;                       startDate: "2024-07-14"

&nbsp;                       endDate: "2024-10-05"

&nbsp;                       price: 65.64

&nbsp;                       zone: "01"

&nbsp;                       weight: 1.2

&nbsp;                       dimensionalWeight: 0.0

&nbsp;                       dimWeight: 0.0

&nbsp;                       fees: \[]

&nbsp;                       priceType: COMMERCIAL\_BASE

&nbsp;                       mailClass: PRIORITY\_MAIL\_EXPRESS\_INTERNATIONAL

&nbsp;                       productName: ""

&nbsp;                       productDefinition: ""

&nbsp;                       processingCategory: "FLATS"

&nbsp;                       rateIndicator: "PA"

&nbsp;                       destinationEntryFacilityType: "INTERNATIONAL\_SERVICE\_CENTER"

&nbsp;                       SKU: IEXX0XXXXB01020

&nbsp;                   extraServices:

&nbsp;                     - name: Insurance <= $500

&nbsp;                       price: 20.15

&nbsp;                       extraService: "930"

&nbsp;                       priceType: COMMERCIAL

&nbsp;                       warnings:

&nbsp;                         - warningCode: "001"

&nbsp;                           warningDescription: Contract rate not found for request. Published rate returned.

&nbsp;                       SKU: IXIE0XXXXCX0500

&nbsp;           priceType: CONTRACT

&nbsp;           paymentAccount:

&nbsp;             accountType: METER

&nbsp;             accountNumber: "123456789"



&nbsp; headers:

&nbsp;   WWWAuthenticate:

&nbsp;     description: Hint to the client application which security scheme to authorize a resource request.

&nbsp;     required: false

&nbsp;     schema:

&nbsp;       type: string

&nbsp;       example: "WWW-Authenticate: Bearer realm=\\"https://api.usps.com\\""

&nbsp;   RetryAfter:

&nbsp;     description: Indicate to the client application a time after which they can retry a resource request.

&nbsp;     required: false

&nbsp;     schema:

&nbsp;       type: string

&nbsp;       example: "Retry-After: 30"

&nbsp; securitySchemes:

&nbsp;   OAuth:

&nbsp;     type: oauth2

&nbsp;     description: The specified APIs accept an access token formatted as a JSON Web Token. The relative path to the OAuth2 version 3 API which supplies this access token is provided below for reference.

&nbsp;     flows:

&nbsp;       clientCredentials:

&nbsp;         tokenUrl: /oauth2/v3/token

&nbsp;         scopes:

&nbsp;           shipments: Read access to Shipping Options API.







---

openapi: 3.0.3

info:

&nbsp; title: International Prices

&nbsp; description: |

&nbsp;   Contact Us: \[USPS API Support](https://emailus.usps.com/s/usps-APIs) | \[Terms of Service](https://about.usps.com/termsofuse.htm)

&nbsp;   

&nbsp;   The International Prices API allows users to retrieve International postage rates for packages by:

&nbsp;   \* Look up International Base Postage based on a set of given package characteristics

&nbsp;   \* Look up International Base Postage based on a given SKU



&nbsp;   The USPS\&#174; has implemented Stock Keeping Units (SKUs) which provide unique identification for their products. These SKUs are available for download online for mailers.





&nbsp;   For further details on package specifications, delivery information, and more, please consult the \[International Mail Manual. (IMM)](https://pe.usps.com/text/imm/welcome.htm).

&nbsp;   For a list of published rates please refer to the \[USPS Price List](https://pe.usps.com/text/dmm300/Notice123.htm)

&nbsp;   To discover the rate ingredients for this API, take a look at \[Publication 205](http://postalpro.usps.com/pub205).







&nbsp;   \*\*Authentication, Authorization and Access Control\*\*

&nbsp;     

&nbsp;     Client applications are given authorized access to protected information resources. Authorization is accomplished via the USPS\&#174; Customer Onboarding Platform, where Customer Registration users may grant applications access to their protected business information. All client applications must go through this onboarding process. Any Customer Registration user wishing to share their protected business information with client application(s) may also grant authorized access.



&nbsp;   The OAuth2, version 3 (/v3), API is based on this authorization grant and must be used to get tokens for all V3 APIs.

&nbsp;   \* The resulting OAuth2 access token is to be placed in the \*\*Authorization\*\* header, using the \*\*Bearer\*\* authentication scheme.

&nbsp;   \* All version 3 APIs validate access to protected information resources and will respond with a \*401\* HTTP status, \*Unauthorized\* reason, when the client application has not been authorized to access the given information resource.



&nbsp;   The following APIs may include payment account or permit identification used to get contract rates.



&nbsp; version: 3.3.9



servers:

&nbsp; - url: https://apis.usps.com/international-prices/v3

&nbsp;   description: Production Environment Endpoint

&nbsp; - url: https://apis-tem.usps.com/international-prices/v3

&nbsp;   description: Testing Environment Endpoint

tags:

\- name: Resources

&nbsp; description: ""

paths:

&nbsp; /base-rates/search:

&nbsp;   post:

&nbsp;     tags:

&nbsp;     - Resources

&nbsp;     summary: Performs a search for international SKUs and price using the submitted rate ingredients.

&nbsp;     description: |

&nbsp;       Given a set of SSF or scan-based rate ingredients, returns a international rates.

&nbsp;       Include contract-based rates in the results when the contractId and productId are present.

&nbsp;     operationId: get-international-base-rates-search

&nbsp;     requestBody:

&nbsp;       description: The search parameters to be used for the query.

&nbsp;       content:

&nbsp;         application/json:

&nbsp;           schema:

&nbsp;             $ref: '#/components/schemas/BaseRatesQuery'

&nbsp;         application/xml:

&nbsp;           schema:

&nbsp;             $ref: '#/components/schemas/BaseRatesQuery'

&nbsp;     responses:

&nbsp;       "200":

&nbsp;         description: Successful Response.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/RateOption'

&nbsp;             examples:

&nbsp;               BaseRatesSearchResponseExample:

&nbsp;                 $ref: '#/components/examples/BaseRatesSearchResponseExample'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/RateOption'

&nbsp;       "400":

&nbsp;         description: Bad Request.  There is an error in the received request.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "401":

&nbsp;         description: Unauthorized request.

&nbsp;         headers:

&nbsp;           WWW-Authenticate:

&nbsp;             $ref: '#/components/headers/WWWAuthenticate'

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "403":

&nbsp;         description: Access is denied.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "404":

&nbsp;         description: Resource Not Found.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "429":

&nbsp;         description: Too Many Requests. Too many requests have been received from client in a short amount of time.

&nbsp;         headers:

&nbsp;           Retry-After:

&nbsp;             $ref: '#/components/headers/RetryAfter'

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "503":

&nbsp;         description: Service is unavailable.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       default:

&nbsp;         description: Other unanticipated errors that may occur.

&nbsp;         content: {}

&nbsp;     security:

&nbsp;     - OAuth:

&nbsp;       - international-prices

&nbsp; /extra-service-rates/search:

&nbsp;   post:

&nbsp;     tags:

&nbsp;     - Resources

&nbsp;     summary: Performs a search for international extra service SKUs using the submitted rate ingredients.

&nbsp;     description: |

&nbsp;       Given a set of rate ingredients, returns international extra service rates.

&nbsp;       If contractId and productId are present, include contract-based rates in the results.

&nbsp;     operationId: get-international-extra-service-rates-search

&nbsp;     requestBody:

&nbsp;       description: The search parameters to be used for the query.

&nbsp;       content:

&nbsp;         application/json:

&nbsp;           schema:

&nbsp;             $ref: '#/components/schemas/ExtraServiceRateQuery'

&nbsp;         application/xml:

&nbsp;           schema:

&nbsp;             $ref: '#/components/schemas/ExtraServiceRateQuery'

&nbsp;     responses:

&nbsp;       "200":

&nbsp;         description: Successful Response.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ExtraServiceRateDetails'

&nbsp;             examples:

&nbsp;               ExtraServiceRatesSearchResponseExample:

&nbsp;                 $ref: '#/components/examples/ExtraServiceRatesSearchResponseExample'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ExtraServiceRateDetails'

&nbsp;       "400":

&nbsp;         description: Bad Request.  There is an error in the received request.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "401":

&nbsp;         description: Unauthorized request.

&nbsp;         headers:

&nbsp;           WWW-Authenticate:

&nbsp;             $ref: '#/components/headers/WWWAuthenticate'

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "403":

&nbsp;         description: Access is denied.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "404":

&nbsp;         description: Resource Not Found.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "429":

&nbsp;         description: Too Many Requests. Too many requests have been received from client in a short amount of time.

&nbsp;         headers:

&nbsp;           Retry-After:

&nbsp;             $ref: '#/components/headers/RetryAfter'

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "503":

&nbsp;         description: Service is unavailable.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       default:

&nbsp;         description: Other unanticipated errors that may occur.

&nbsp;         content: {}

&nbsp;     security:

&nbsp;     - OAuth:

&nbsp;       - international-prices

&nbsp; /base-rates-list/search:

&nbsp;   post:

&nbsp;     tags:

&nbsp;     - Resources

&nbsp;     summary: Performs a search for a International rate (outbound only) using the submitted values.

&nbsp;     description: |

&nbsp;       Given size/weight/destination of pieces, returns a list of potential rates. Can also search for contract rates by providing mailer id, EPS, permit number or vendor number and account.     If searching for contract rates, then a specified mail class is required.

&nbsp;     operationId: get-rate-list

&nbsp;     requestBody:

&nbsp;       description: The search parameters to be used for the query.

&nbsp;       content:

&nbsp;         application/json:

&nbsp;           schema:

&nbsp;             $ref: '#/components/schemas/InternationalRateListQuery'

&nbsp;         application/xml:

&nbsp;           schema:

&nbsp;             $ref: '#/components/schemas/InternationalRateListQuery'

&nbsp;     responses:

&nbsp;       "200":

&nbsp;         description: Successful Response.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/InternationalRateListQueryResult'

&nbsp;             examples:

&nbsp;               BaseRatesListSearchResponseExample:

&nbsp;                 $ref: '#/components/examples/BaseRatesListSearchResponseExample'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/InternationalRateListQueryResult'

&nbsp;       "400":

&nbsp;         description: Bad Request.  There is an error in the received request.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "401":

&nbsp;         description: Unauthorized request.

&nbsp;         headers:

&nbsp;           WWW-Authenticate:

&nbsp;             $ref: '#/components/headers/WWWAuthenticate'

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "403":

&nbsp;         description: Access is denied.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "404":

&nbsp;         description: Resource Not Found.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "429":

&nbsp;         description: Too Many Requests. Too many requests have been received from client in a short amount of time.

&nbsp;         headers:

&nbsp;           Retry-After:

&nbsp;             $ref: '#/components/headers/RetryAfter'

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "503":

&nbsp;         description: Service is unavailable.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       default:

&nbsp;         description: Other unanticipated errors that may occur.

&nbsp;         content: {}

&nbsp;     security:

&nbsp;     - OAuth:

&nbsp;       - international-prices

&nbsp; /total-rates/search:

&nbsp;   post:

&nbsp;     tags:

&nbsp;     - Resources

&nbsp;     summary: Returns an eligible price given a set of package rate ingredients.

&nbsp;     description: |

&nbsp;       Performs a search for base price and extraServices using the submitted rate ingredients.  If itemValue is not included the response will not include insurance, registered mail, and collect on delivery extra services.  If the extraService array is not specified then all eligible extra services will be included.

&nbsp;     operationId: post-total-rates-search

&nbsp;     requestBody:

&nbsp;       description: The search parameters to be used for the query.

&nbsp;       content:

&nbsp;         application/json:

&nbsp;           schema:

&nbsp;             $ref: '#/components/schemas/TotalRatesQuery'

&nbsp;         application/xml:

&nbsp;           schema:

&nbsp;             $ref: '#/components/schemas/TotalRatesQuery'

&nbsp;     responses:

&nbsp;       "200":

&nbsp;         description: Successful Response

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/TotalRatesQueryResult'

&nbsp;             examples:

&nbsp;               TotalRatesSearchResponseExample:

&nbsp;                 $ref: '#/components/examples/TotalRatesSearchResponseExample'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/TotalRatesQueryResult'

&nbsp;       "400":

&nbsp;         description: Bad Request.  There is an error in the received request.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "401":

&nbsp;         description: Unauthorized request.

&nbsp;         headers:

&nbsp;           WWW-Authenticate:

&nbsp;             $ref: '#/components/headers/WWWAuthenticate'

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "403":

&nbsp;         description: Access is denied.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "404":

&nbsp;         description: Resource Not Found

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "429":

&nbsp;         description: Too Many Requests. Too many requests have been received from client in a short amount of time.

&nbsp;         headers:

&nbsp;           Retry-After:

&nbsp;             $ref: '#/components/headers/RetryAfter'

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "503":

&nbsp;         description: Service is unavailable

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       default:

&nbsp;         description: Other unanticipated errors that may occur.

&nbsp;         content: {}

&nbsp;     security:

&nbsp;     - OAuth:

&nbsp;       - international-prices

&nbsp; /letter-rates/search:

&nbsp;   post:

&nbsp;     tags:

&nbsp;       - Resources

&nbsp;     summary: Performs a search for First-Class Mail International letter prices using the submitted rate ingredients.

&nbsp;     description: |

&nbsp;       Returns an eligible price given a set of letter rate ingredients for First-Class Mail International.

&nbsp;     operationId: post-letter-rates-search

&nbsp;     requestBody:

&nbsp;       description: The search parameters to be used for the query.

&nbsp;       content:

&nbsp;         application/json:

&nbsp;           schema:

&nbsp;             $ref: '#/components/schemas/InternationalLetterRatesQuery'

&nbsp;         application/xml:

&nbsp;           schema:

&nbsp;             $ref: '#/components/schemas/InternationalLetterRatesQuery'

&nbsp;     responses:

&nbsp;       "200":

&nbsp;         description: Successful Response

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/LetterRatesOption'

&nbsp;             examples:

&nbsp;               LetterRatesSearchResponseExample:

&nbsp;                 $ref: '#/components/examples/LetterRatesSearchResponseExample'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/LetterRatesOption'

&nbsp;       "400":

&nbsp;         description: Bad Request.  There is an error in the received request.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "401":

&nbsp;         description: Unauthorized request.

&nbsp;         headers:

&nbsp;           WWW-Authenticate:

&nbsp;             $ref: '#/components/headers/WWWAuthenticate'

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "403":

&nbsp;         description: Access is denied.

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "404":

&nbsp;         description: Resource Not Found

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "429":

&nbsp;         description: Too Many Requests. Too many requests have been received from client in a short amount of time.

&nbsp;         headers:

&nbsp;           Retry-After:

&nbsp;             $ref: '#/components/headers/RetryAfter'

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       "503":

&nbsp;         description: Service is unavailable

&nbsp;         content:

&nbsp;           application/json:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;           application/xml:

&nbsp;             schema:

&nbsp;               $ref: '#/components/schemas/ErrorMessage'

&nbsp;       default:

&nbsp;         description: Other unanticipated errors that may occur.

&nbsp;         content: { }

&nbsp;     security:

&nbsp;       - OAuth:

&nbsp;           - international-prices

components:

&nbsp; schemas:

&nbsp;   BaseRatesQuery:

&nbsp;     title: International Base Rates Query

&nbsp;     required:

&nbsp;     - destinationCountryCode

&nbsp;     - destinationEntryFacilityType

&nbsp;     - height

&nbsp;     - length

&nbsp;     - mailClass

&nbsp;     - originZIPCode

&nbsp;     - priceType

&nbsp;     - processingCategory

&nbsp;     - rateIndicator

&nbsp;     - weight

&nbsp;     - width

&nbsp;     type: object

&nbsp;     properties:

&nbsp;       originZIPCode:

&nbsp;         $ref: '#/components/schemas/originZIPCode'

&nbsp;       weight:

&nbsp;         $ref: '#/components/schemas/weightPounds'

&nbsp;       length:

&nbsp;         $ref: '#/components/schemas/length'

&nbsp;       width:

&nbsp;         $ref: '#/components/schemas/width'

&nbsp;       height:

&nbsp;         $ref: '#/components/schemas/height'

&nbsp;       mailClass:

&nbsp;         type: string

&nbsp;         description: |-

&nbsp;           The mail service requested.

&nbsp;            \* 'FIRST-CLASS\_PACKAGE\_INTERNATIONAL\_SERVICE'

&nbsp;            \* 'PRIORITY\_MAIL\_INTERNATIONAL'

&nbsp;            \* 'PRIORITY\_MAIL\_EXPRESS\_INTERNATIONAL'

&nbsp;            \* 'GLOBAL\_EXPRESS\_GUARANTEED' - Global Express Guaranteed Service is suspended as of September 29, 2024.

&nbsp;         enum:

&nbsp;         - FIRST-CLASS\_PACKAGE\_INTERNATIONAL\_SERVICE

&nbsp;         - PRIORITY\_MAIL\_INTERNATIONAL

&nbsp;         - PRIORITY\_MAIL\_EXPRESS\_INTERNATIONAL

&nbsp;         - GLOBAL\_EXPRESS\_GUARANTEED

&nbsp;       processingCategory:

&nbsp;         type: string

&nbsp;         description: |-

&nbsp;           Value designates if shipment is `MACHINABLE`, `NONSTANDARD, or `FLATS`.

&nbsp;           

&nbsp;           Note:

&nbsp;           \* `NON\_MACHINABLE` is deprecated and will convert to `NONSTANDARD` as of 01/19/2025.

&nbsp;         enum:

&nbsp;         - FLATS

&nbsp;         - MACHINABLE

&nbsp;         - NON\_MACHINABLE

&nbsp;         - NONSTANDARD

&nbsp;       rateIndicator:

&nbsp;         type: string

&nbsp;         description: |-

&nbsp;           Use to specify USPS\&#174; containers/packaging or container attributes that may affect postage.

&nbsp;            \* E4 - Priority Mail Express Flat Rate Envelope - Post Office To Addressee

&nbsp;            \* E6 - Priority Mail Express Legal Flat Rate Envelope

&nbsp;            \* FA - Legal Flat Rate Envelope

&nbsp;            \* FB - Medium Flat Rate Box/Large Flat Rate Bag

&nbsp;            \* FE - Flat Rate Envelope

&nbsp;            \* FP - Padded Flat Rate Envelope

&nbsp;            \* FS - Small Flat Rate Box

&nbsp;            \* PA - Priority Mail Express International Single Piece

&nbsp;            \* PL - Large Flat Rate Box

&nbsp;            \* SP - Single Piece

&nbsp;            \* EP - ECOMPRO Single Piece

&nbsp;            \* HA - ECOMPRO Legal Flat Rate Envelope

&nbsp;            \* HB - ECOMPRO Medium Flat Rate Box

&nbsp;            \* HE - ECOMPRO Flat Rate Envelope

&nbsp;            \* HL - ECOMPRO Large Flat Rate Box

&nbsp;            \* HP - ECOMPRO Padded Flat Rate Envelope

&nbsp;            \* HS - ECOMPRO Small Flat Rate Box

&nbsp;            \* LE - Single-piece parcel

&nbsp;         enum:

&nbsp;         - E4

&nbsp;         - E6

&nbsp;         - E7

&nbsp;         - FA

&nbsp;         - FB

&nbsp;         - FE

&nbsp;         - FP

&nbsp;         - FS

&nbsp;         - PA

&nbsp;         - PL

&nbsp;         - SP

&nbsp;         - EP

&nbsp;         - HA

&nbsp;         - HB

&nbsp;         - HE

&nbsp;         - HL

&nbsp;         - HP

&nbsp;         - HS

&nbsp;         - LE

&nbsp;       destinationEntryFacilityType:

&nbsp;         type: string

&nbsp;         description: "Types of Facilities \\n  \* NONE - Translate to Destination Rate Indicator N\\n  \* INTERNATIONAL\_SERVICE\_CENTER - Translate to Destination Rate Indicator I"

&nbsp;         enum:

&nbsp;         - NONE

&nbsp;         - INTERNATIONAL\_SERVICE\_CENTER

&nbsp;       priceType:

&nbsp;         $ref: '#/components/schemas/internationalPriceType'

&nbsp;       mailingDate:

&nbsp;         $ref: '#/components/schemas/mailingDate'

&nbsp;       foreignPostalCode:

&nbsp;         type: string

&nbsp;         description: The foreign ZIP Code\&#8482; for the package.

&nbsp;       destinationCountryCode:

&nbsp;         $ref: '#/components/schemas/DestinationCountryCode'

&nbsp;       accountType:

&nbsp;         type: string

&nbsp;         description: |

&nbsp;           The type of payment account linked to a contract rate.



&nbsp;           Note:

&nbsp;           - `METER` pricing is only available to PC Postage providers.

&nbsp;         example: EPS

&nbsp;         enum:

&nbsp;         - EPS

&nbsp;         - PERMIT

&nbsp;         - METER

&nbsp;       accountNumber:

&nbsp;         pattern: ^\\d+$

&nbsp;         type: string

&nbsp;         description: "The Enterprise Payment Account, Permit number or PC Postage meter number associated with a contract."

&nbsp;     additionalProperties: false

&nbsp;     description: Search parameters for base rates.

&nbsp;     xml:

&nbsp;       name: baseRateQuery

&nbsp;       wrapped: true

&nbsp;   ExtraServiceRateQuery:

&nbsp;     title: International Extra Service Rate Query

&nbsp;     required:

&nbsp;     - destinationCountryCode

&nbsp;     - mailClass

&nbsp;     - priceType

&nbsp;     - rateIndicator

&nbsp;     - weight

&nbsp;     type: object

&nbsp;     properties:

&nbsp;       extraServices:

&nbsp;         type: array

&nbsp;         description: |-

&nbsp;           Extra Service Code requested

&nbsp;            \* `370` - USPS Delivery Duties Paid Fee

&nbsp;            \* `813` - HAZMAT Class 7 - Radioactive Materials Package

&nbsp;            \* `820` - HAZMAT Class 9 - Lithium batteries, unmarked package

&nbsp;            \* `826` - HAZMAT Division 6.2 – Infectious Substances Package

&nbsp;            \* `857` - Hazardous Material

&nbsp;            \* `930` - Insurance <= $500

&nbsp;            \* `931` - Insurance > $500

&nbsp;            \* `955` - Return Receipt (Unsupported as of 01/19/2025)

&nbsp;         items:

&nbsp;           type: integer

&nbsp;           enum:

&nbsp;           - 370

&nbsp;           - 813

&nbsp;           - 820

&nbsp;           - 826

&nbsp;           - 857

&nbsp;           - 930

&nbsp;           - 931

&nbsp;           - 955

&nbsp;       extraService:

&nbsp;         title: Extra Service Codes

&nbsp;         type: integer

&nbsp;         description: |-

&nbsp;           Extra Service Code requested

&nbsp;            \* `370` - USPS Delivery Duties Paid Fee

&nbsp;            \* `813` - HAZMAT Class 7 - Radioactive Materials Package

&nbsp;            \* `820` - HAZMAT Class 9 - Lithium batteries, unmarked package

&nbsp;            \* `826` - HAZMAT Division 6.2 – Infectious Substances Package

&nbsp;            \* `857` - Hazardous Material

&nbsp;            \* `930` - Insurance <= $500

&nbsp;            \* `931` - Insurance > $500

&nbsp;            \* `955` - Return Receipt (Unsupported as of 01/19/2025)

&nbsp;         enum:

&nbsp;         - 370

&nbsp;         - 813

&nbsp;         - 820

&nbsp;         - 826

&nbsp;         - 857

&nbsp;         - 930

&nbsp;         - 931

&nbsp;         - 955

&nbsp;       mailClass:

&nbsp;         type: string

&nbsp;         description: |-

&nbsp;           The mail service requested.

&nbsp;            \* 'FIRST-CLASS\_PACKAGE\_INTERNATIONAL\_SERVICE'

&nbsp;            \* 'PRIORITY\_MAIL\_INTERNATIONAL'

&nbsp;            \* 'PRIORITY\_MAIL\_EXPRESS\_INTERNATIONAL'

&nbsp;            \* 'GLOBAL\_EXPRESS\_GUARANTEED' - Global Express Guaranteed Service is suspended as of September 29, 2024.

&nbsp;         enum:

&nbsp;         - FIRST-CLASS\_PACKAGE\_INTERNATIONAL\_SERVICE

&nbsp;         - PRIORITY\_MAIL\_INTERNATIONAL

&nbsp;         - PRIORITY\_MAIL\_EXPRESS\_INTERNATIONAL

&nbsp;         - GLOBAL\_EXPRESS\_GUARANTEED

&nbsp;       priceType:

&nbsp;         type: string

&nbsp;         description: "Price type can be \\n  \* 'RETAIL'\\n  \* 'COMMERCIAL'\\n  \* 'COMMERCIAL\_PLUS'\\n  \* 'NSA"

&nbsp;         enum:

&nbsp;         - RETAIL

&nbsp;         - COMMERCIAL

&nbsp;         - COMMERCIAL\_PLUS

&nbsp;         - NSA

&nbsp;       itemValue:

&nbsp;         type: string

&nbsp;         description: 'The value of the item. Required for Insurance and Registered Mail.'

&nbsp;       weight:

&nbsp;         $ref: '#/components/schemas/weightPounds'

&nbsp;       mailingDate:

&nbsp;         $ref: '#/components/schemas/mailingDate'

&nbsp;       rateIndicator:

&nbsp;         type: string

&nbsp;         description: |-

&nbsp;           Use to specify USPS containers/packaging or container attributes that may affect postage.

&nbsp;            \* E4 - Priority Mail Express Flat Rate Envelope - Post Office To Addressee

&nbsp;            \* E6 - Priority Mail Express Legal Flat Rate Envelope

&nbsp;            \* FA - Legal Flat Rate Envelope

&nbsp;            \* FB - Medium Flat Rate Box/Large Flat Rate Bag

&nbsp;            \* FE - Flat Rate Envelope

&nbsp;            \* FP - Padded Flat Rate Envelope

&nbsp;            \* FS - Small Flat Rate Box

&nbsp;            \* PA - Priority Mail Express International Single Piece

&nbsp;            \* PL - Large Flat Rate Box

&nbsp;            \* SP - Single Piece

&nbsp;            \* EP - ECOMPRO Single Piece

&nbsp;            \* HA - ECOMPRO Legal Flat Rate Envelope

&nbsp;            \* HB - ECOMPRO Medium Flat Rate Box

&nbsp;            \* HE - ECOMPRO Flat Rate Envelope

&nbsp;            \* HL - ECOMPRO Large Flat Rate Box

&nbsp;            \* HP - ECOMPRO Padded Flat Rate Envelope

&nbsp;            \* HS - ECOMPRO Small Flat Rate Box

&nbsp;            \* LE - Single-piece parcel

&nbsp;         enum:

&nbsp;         - E4

&nbsp;         - E6

&nbsp;         - E7

&nbsp;         - FA

&nbsp;         - FB

&nbsp;         - FE

&nbsp;         - FP

&nbsp;         - FS

&nbsp;         - PA

&nbsp;         - PL

&nbsp;         - SP

&nbsp;         - EP

&nbsp;         - HA

&nbsp;         - HB

&nbsp;         - HE

&nbsp;         - HL

&nbsp;         - HP

&nbsp;         - HS

&nbsp;         - LE

&nbsp;       destinationCountryCode:

&nbsp;         $ref: '#/components/schemas/DestinationCountryCode'

&nbsp;       accountType:

&nbsp;         type: string

&nbsp;         description: |

&nbsp;           The type of payment account linked to a contract rate.



&nbsp;           Note:

&nbsp;           - `METER` pricing is only available to PC Postage providers.

&nbsp;         example: EPS

&nbsp;         enum:

&nbsp;         - EPS

&nbsp;         - PERMIT

&nbsp;         - METER

&nbsp;       accountNumber:

&nbsp;         pattern: ^\\d+$

&nbsp;         type: string

&nbsp;         description: "The Enterprise Payment Account, Permit number or PC Postage meter number associated with a contract."

&nbsp;     additionalProperties: false

&nbsp;     description: Search parameters for extra services rates.

&nbsp;     xml:

&nbsp;       name: extraServiceRateQuery

&nbsp;       wrapped: true

&nbsp;   ExtraServiceRateDetails:

&nbsp;     title: International Extra Rate Details

&nbsp;     description: International pricing extra service details being returned from the API.

&nbsp;     type: object

&nbsp;     properties:

&nbsp;       extraServices:

&nbsp;         description: List of extra services associated with the shipment.

&nbsp;         type: array

&nbsp;         items:

&nbsp;           type: object

&nbsp;           properties:

&nbsp;             SKU:

&nbsp;               $ref: '#/components/schemas/SKU'

&nbsp;             price:

&nbsp;               $ref: '#/components/schemas/price'

&nbsp;             priceType:

&nbsp;               $ref: '#/components/schemas/internationalPriceType'

&nbsp;             extraService:

&nbsp;               title: Extra Service Codes

&nbsp;               type: integer

&nbsp;               description: |

&nbsp;                 Extra Service Code requested

&nbsp;                 \* `370` - USPS Delivery Duties Paid Fee

&nbsp;                 \* `813` - HAZMAT Class 7 - Radioactive Materials Package

&nbsp;                 \* `820` - HAZMAT Class 9 - Lithium batteries, unmarked package

&nbsp;                 \* `826` - HAZMAT Division 6.2 – Infectious Substances Package

&nbsp;                 \* `857` - Hazardous Material

&nbsp;                 \* `930` - Insurance <= $500

&nbsp;                 \* `931` - Insurance > $500

&nbsp;                 \* `955` - Return Receipt (Unsupported as of 01/19/2025)

&nbsp;               example: 930

&nbsp;               enum:

&nbsp;                 - 370

&nbsp;                 - 813

&nbsp;                 - 820

&nbsp;                 - 826

&nbsp;                 - 857

&nbsp;                 - 930

&nbsp;                 - 931

&nbsp;                 - 955

&nbsp;             name:

&nbsp;               $ref: '#/components/schemas/ExtraServiceName'

&nbsp;             warnings:

&nbsp;               $ref: '#/components/schemas/WarningsList'

&nbsp;   ExtraServiceName:

&nbsp;     type: string

&nbsp;     description: Description of the Extra Service

&nbsp;     example: Insurance <= $500

&nbsp;   InternationalRateListQuery:

&nbsp;     title: International Rate List Query

&nbsp;     required:

&nbsp;     - destinationCountryCode

&nbsp;     - height

&nbsp;     - length

&nbsp;     - originZIPCode

&nbsp;     - weight

&nbsp;     - width

&nbsp;     type: object

&nbsp;     properties:

&nbsp;       originZIPCode:

&nbsp;         $ref: '#/components/schemas/originZIPCode'

&nbsp;       foreignPostalCode:

&nbsp;         type: string

&nbsp;         description: The foreign ZIP Code\&#8482; for the package.

&nbsp;       destinationCountryCode:

&nbsp;         $ref: '#/components/schemas/DestinationCountryCode'

&nbsp;       weight:

&nbsp;         $ref: '#/components/schemas/weightPounds'

&nbsp;       mailingDate:

&nbsp;         $ref: '#/components/schemas/mailingDate'

&nbsp;       length:

&nbsp;         $ref: '#/components/schemas/length'

&nbsp;       width:

&nbsp;         $ref: '#/components/schemas/width'

&nbsp;       height:

&nbsp;         $ref: '#/components/schemas/height'

&nbsp;       priceType:

&nbsp;         $ref: '#/components/schemas/internationalPriceType'

&nbsp;       mailClass:

&nbsp;         type: string

&nbsp;         description: |-

&nbsp;           The mail service requested.

&nbsp;            \* 'FIRST-CLASS\_PACKAGE\_INTERNATIONAL\_SERVICE'

&nbsp;            \* 'PRIORITY\_MAIL\_INTERNATIONAL'

&nbsp;            \* 'PRIORITY\_MAIL\_EXPRESS\_INTERNATIONAL'

&nbsp;            \* 'GLOBAL\_EXPRESS\_GUARANTEED' - Global Express Guaranteed Service is suspended as of September 29, 2024.

&nbsp;            \* 'ALL'

&nbsp;         enum:

&nbsp;         - FIRST-CLASS\_PACKAGE\_INTERNATIONAL\_SERVICE

&nbsp;         - PRIORITY\_MAIL\_INTERNATIONAL

&nbsp;         - PRIORITY\_MAIL\_EXPRESS\_INTERNATIONAL

&nbsp;         - GLOBAL\_EXPRESS\_GUARANTEED

&nbsp;         - ALL

&nbsp;       accountType:

&nbsp;         type: string

&nbsp;         description: |

&nbsp;           The type of payment account linked to a contract rate.



&nbsp;           Note:

&nbsp;           - `METER` pricing is only available to PC Postage providers.

&nbsp;         example: EPS

&nbsp;         enum:

&nbsp;         - EPS

&nbsp;         - PERMIT

&nbsp;         - METER

&nbsp;       accountNumber:

&nbsp;         pattern: ^\\d+$

&nbsp;         type: string

&nbsp;         description: "The Enterprise Payment Account, Permit number or PC Postage meter number associated with a contract."

&nbsp;     additionalProperties: false

&nbsp;     description: Informative details about all possible rate based on the ingredients.

&nbsp;     xml:

&nbsp;       name: internationalratelistquery

&nbsp;       wrapped: true

&nbsp;   InternationalRateListQueryResult:

&nbsp;     description: A list of rate options.

&nbsp;     type: object

&nbsp;     properties:

&nbsp;       rateOptions:

&nbsp;         $ref: '#/components/schemas/RateOptions'

&nbsp;     xml:

&nbsp;       name: rateOptions

&nbsp;       wrapped: true

&nbsp;   TotalRatesQuery:

&nbsp;     title: Total Rates Query

&nbsp;     type: object

&nbsp;     description: Search parameters for base rate and extra service rate.

&nbsp;     allOf:

&nbsp;     - $ref: '#/components/schemas/InternationalRateListQuery'

&nbsp;     - type: object

&nbsp;       properties:

&nbsp;         requestDutiesTaxesFees:

&nbsp;           type: boolean

&nbsp;           description: 'When `true` the returned `rateOption` elements will include the duties and taxes cost for each item and package fees.'

&nbsp;           default: false

&nbsp;         destinationCity:

&nbsp;           type: string

&nbsp;           maxLength: 28

&nbsp;           minLength: 1

&nbsp;           description: 'When `requestDutiesTaxesFees` is `true` then `destinationCity` may be required based on the country of import.'

&nbsp;         destinationState:

&nbsp;           type: string

&nbsp;           maxLength: 2

&nbsp;           minLength: 2

&nbsp;           pattern: "^\\\\w{2}$"

&nbsp;           description: 'When `requestDutiesTaxesFees` is `true` then `destinationState` may be required based on the country of import.'

&nbsp;         items:

&nbsp;           type: array

&nbsp;           maxItems: 30

&nbsp;           description: 'A list of items utilized for pricing when `requestDutiesTaxesFees` is `true`.'

&nbsp;           items:

&nbsp;             $ref: '#/components/schemas/TotalRatesRequestLandedCostItem'

&nbsp;         itemValue:

&nbsp;           type: number

&nbsp;           description: 'The value of the all items in the package. Required for Insurance and Registered Mail.'

&nbsp;           format: double

&nbsp;           minimum: 0

&nbsp;         extraServices:

&nbsp;           type: array

&nbsp;           description: A list of Extra Services to be included in the total rates search. If no extra services are specified all applicable extra services for the mail class will be returned.

&nbsp;           items:

&nbsp;             type: integer

&nbsp;             description: |-

&nbsp;               Extra Service Code requested

&nbsp;                \* `370` - USPS Delivery Duties Paid Fee

&nbsp;                \* `813` - HAZMAT Class 7 - Radioactive Materials Package

&nbsp;                \* `820` - HAZMAT Class 9 - Lithium batteries, unmarked package

&nbsp;                \* `826` - HAZMAT Division 6.2 – Infectious Substances Package

&nbsp;                \* `857` - Hazardous Material

&nbsp;                \* `930` - Insurance <= $500

&nbsp;                \* `931` - Insurance > $500

&nbsp;                \* `955` - Return Receipt (Unsupported as of 01/19/2025)

&nbsp;             enum:

&nbsp;             - 370

&nbsp;             - 813

&nbsp;             - 820

&nbsp;             - 826

&nbsp;             - 857

&nbsp;             - 930

&nbsp;             - 931

&nbsp;             - 955

&nbsp;   TotalRatesQueryResult:

&nbsp;     title: Total Rate Details

&nbsp;     type: object

&nbsp;     properties:

&nbsp;       rateOptions:

&nbsp;         type: array

&nbsp;         description: List of rate options including total base price and rates

&nbsp;         xml:

&nbsp;           name: rateOptions

&nbsp;         items:

&nbsp;           allOf:

&nbsp;           - $ref: '#/components/schemas/RateOption'

&nbsp;           - type: object

&nbsp;             properties:

&nbsp;               dutiesTaxesFeesQuote:

&nbsp;                 type: object

&nbsp;                 description: "The duties, taxes, and fees details. Included if `requestDutiesTaxesFees` is `true` and the shipping destination has applicable duties, taxes, and fees."

&nbsp;                 properties:

&nbsp;                   packageFee:

&nbsp;                     type: number

&nbsp;                     format: float

&nbsp;                     description: "The value of the total landed cost fee associated with the package."

&nbsp;                   itemQuotes:

&nbsp;                     type: array

&nbsp;                     description: "The total landed cost prices for taxes and duties on each item."

&nbsp;                     items:

&nbsp;                       type: object

&nbsp;                       properties:

&nbsp;                         dutyPrice:

&nbsp;                           type: number

&nbsp;                           format: float

&nbsp;                           description: "The value of the duties associated with the item."

&nbsp;                         taxPrice:

&nbsp;                           type: number

&nbsp;                           format: float

&nbsp;                           description: "The value of the taxes associated with the item."

&nbsp;                         itemId:

&nbsp;                           type: string

&nbsp;                           description: "The corresponding `itemId` provided in the request."

&nbsp;               extraServices:

&nbsp;                 type: array

&nbsp;                 description: A list of Extra Services to be included in the total rates search. If no extra services are specified all applicable extra services for the mail class will be returned.

&nbsp;                 items:

&nbsp;                   type: object

&nbsp;                   properties:

&nbsp;                     SKU:

&nbsp;                       $ref: '#/components/schemas/SKU'

&nbsp;                     price:

&nbsp;                       $ref: '#/components/schemas/price'

&nbsp;                     priceType:

&nbsp;                       $ref: '#/components/schemas/internationalPriceType'

&nbsp;                     extraService:

&nbsp;                       type: string

&nbsp;                       description: Extra Service Code

&nbsp;                       example: "930"

&nbsp;                     name:

&nbsp;                       $ref: '#/components/schemas/ExtraServiceName'

&nbsp;                     warnings:

&nbsp;                       $ref: '#/components/schemas/WarningsList'

&nbsp;               totalPrice:

&nbsp;                 type: number

&nbsp;                 description: |

&nbsp;                   The total price, including the `totalBasePrice` and all extra service prices.



&nbsp;                   Note: This field is only returned when `extraServices` are passed in the request.

&nbsp;                 example: 3.35

&nbsp;     description: A list of rate options including applicable extra services.

&nbsp;   InternationalLetterRatesQuery:

&nbsp;     title: International Letter Rates Query

&nbsp;     required:

&nbsp;       - height

&nbsp;       - length

&nbsp;       - processingCategory

&nbsp;       - thickness

&nbsp;       - weight

&nbsp;       - destinationCountryCode

&nbsp;     type: object

&nbsp;     properties:

&nbsp;       weight:

&nbsp;         $ref: '#/components/schemas/weightOunces'

&nbsp;       length:

&nbsp;         minimum: 0

&nbsp;         exclusiveMinimum: true

&nbsp;         type: number

&nbsp;         description: The letter/flat length measured in inches.  For  \_`LETTERS`\_ the length is the dimension parallel to the delivery address as read. For  \_`FLATS`\_ the length is the longest dimension.

&nbsp;         format: double

&nbsp;       height:

&nbsp;         minimum: 0

&nbsp;         exclusiveMinimum: true

&nbsp;         type: number

&nbsp;         description: The letter/flat height measured in inches.  The height is the dimension perpendicular to the length.

&nbsp;         format: double

&nbsp;       thickness:

&nbsp;         minimum: 0

&nbsp;         exclusiveMinimum: true

&nbsp;         type: number

&nbsp;         description: The letter/flat thickness measured in inches. The minimum dimension is always the thickness.

&nbsp;         format: double

&nbsp;       processingCategory:

&nbsp;         type: string

&nbsp;         description: "To be eligible for mailing at the price for letters, a piece must be:\\n   \* Rectangular\\n   \* At least 3-1/2 inches high x 5 inches long x 0.007 inch thick.\\n   \* No more than 6-1/8 inches high x 11-1/2 inches long x 1/4 inch thick.\\n  \\nFor additional information on letters, please refer to the \[Postal Explorer](https://pe.usps.com/businessmail101?ViewName=Letters).\\n\\nThe Postal Service uses the word \\"flats\\" to refer to large envelopes, newsletters, and magazines. The words large envelopes and flats are used interchangeably. Whatever you call them, flats must:\\n\\n   \* Have one dimension that is greater than 6-1/8 inches high OR 11-½ inches long OR ¼ inch thick.\\n   \* Be no more than 12 inches high x 15 inches long x ¾ inch thick.\\n  \\n For additional information on flats, please refer to the \[Postal Explorer](https://pe.usps.com/businessmail101?ViewName=Flats). \\n\\n \* LETTERS\\n \* FLATS         "

&nbsp;         enum:

&nbsp;           - LETTERS

&nbsp;           - FLATS

&nbsp;           - CARDS

&nbsp;       mailingDate:

&nbsp;         $ref: '#/components/schemas/mailingDate'

&nbsp;       nonMachinableIndicators:

&nbsp;         type: object

&nbsp;         properties:

&nbsp;           isPolybagged:

&nbsp;             type: boolean

&nbsp;             description: "Is the letter/flat polybagged, polywrapped, enclosed in any plastic material, or has an exterior surface made of a material that is not paper. Windows in envelopes made of paper do not make mailpieces nonmachinable. Attachments allowable under applicable eligibility standards do not make mailpieces nonmachinable."

&nbsp;             default: false

&nbsp;           hasClosureDevices:

&nbsp;             type: boolean

&nbsp;             description: "Does the letter/flat have clasps, strings, buttons, or similar closure devices."

&nbsp;             default: false

&nbsp;           hasLooseItems:

&nbsp;             type: boolean

&nbsp;             description: "Does the letter/flat contain items such as pens, pencils, keys, or coins that cause the thickness of the mailpiece to be uneven; or loose keys or coins or similar objects not affixed to the contents within the mailpiece. Loose items may cause a letter to be nonmailable when mailed in paper envelopes; (see \[DMM 601.3.3](https://pe.usps.com/text/dmm300/601.htm#ep1196660))."

&nbsp;             default: false

&nbsp;           isRigid:

&nbsp;             type: boolean

&nbsp;             description: Is the letter/flat too rigid (does not bend easily when subjected to a transport belt tension of 40 pounds around an 11-inch diameter turn).

&nbsp;             default: false

&nbsp;           isSelfMailer:

&nbsp;             type: boolean

&nbsp;             description: "Is the letter/flat a self-mailer that is not prepared according to \[DMM 201.3.14](https://pe.usps.com/text/dmm300/201.htm#ep1079302)."

&nbsp;             default: false

&nbsp;           isBooklet:

&nbsp;             type: boolean

&nbsp;             description: "Is the letter/flat a booklet that is not prepared according to \[DMM 201.3.16](https://pe.usps.com/text/dmm300/201.htm#ep1092751)."

&nbsp;             default: false

&nbsp;         additionalProperties: false

&nbsp;         description: Set of boolean indicators used to determine whether a letter qualifies as nonmachinable.

&nbsp;       extraServices:

&nbsp;         type: array

&nbsp;         description: |

&nbsp;           Extra Service Code requested.

&nbsp;           \* 940 - Registered Mail

&nbsp;           \* 955 - Return Receipt

&nbsp;         items:

&nbsp;           type: integer

&nbsp;           enum:

&nbsp;             - 940

&nbsp;             - 955

&nbsp;       destinationCountryCode:

&nbsp;         $ref: '#/components/schemas/DestinationCountryCode'

&nbsp;       itemValue:

&nbsp;         type: number

&nbsp;         description: 'The value of the item. Required for insurance.'

&nbsp;         format: double

&nbsp;         minimum: 0

&nbsp;     additionalProperties: false

&nbsp;     description: Letter rate ingredients for calculating base prices.

&nbsp;     xml:

&nbsp;       wrapped: true

&nbsp;   RateOption:

&nbsp;     title: Base Rates Query Result

&nbsp;     type: object

&nbsp;     properties:

&nbsp;       totalBasePrice:

&nbsp;         type: number

&nbsp;         description: "The total price, including the rate, fees and pound postage."

&nbsp;         example: 3.35

&nbsp;       rates:

&nbsp;         type: array

&nbsp;         description: List of rate details, including SKU, description and rate ingredients

&nbsp;         xml:

&nbsp;           wrapped: true

&nbsp;         items:

&nbsp;           $ref: '#/components/schemas/RateDetails'

&nbsp;     additionalProperties: true

&nbsp;     description: The prices that match the search criteria.

&nbsp;     xml:

&nbsp;       name: rateOption

&nbsp;   RateDetails:

&nbsp;     title: Rate Details

&nbsp;     type: object

&nbsp;     properties:

&nbsp;       SKU:

&nbsp;         type: string

&nbsp;         description: The stock keeping unit for the designated rate.

&nbsp;         example: DPXX0XXXXX07200

&nbsp;       description:

&nbsp;         type: string

&nbsp;         description: The description of the price.

&nbsp;       priceType:

&nbsp;         type: string

&nbsp;         description: |-

&nbsp;           The type of price applied.

&nbsp;            \* Valid Options for Domestic Prices include: 'RETAIL','COMMERCIAL' \& 'CONTRACT'

&nbsp;            \* Valid Options for International Prices include: 'RETAIL', 'COMMERCIAL', 'COMMERCIAL\_BASE', 'COMMERCIAL\_PLUS' \& 'CONTRACT'

&nbsp;         enum:

&nbsp;         - RETAIL

&nbsp;         - COMMERCIAL

&nbsp;         - COMMERCIAL\_BASE

&nbsp;         - COMMERCIAL\_PLUS

&nbsp;         - CONTRACT

&nbsp;       price:

&nbsp;         type: number

&nbsp;         description: The postage price.

&nbsp;         format: double

&nbsp;         example: 3.35

&nbsp;       weight:

&nbsp;         type: number

&nbsp;         description: The calculated weight for the package based on user input.  The greater of dimWeight and weight will be used to calculated the rate.

&nbsp;         format: double

&nbsp;         example: 5

&nbsp;       dimWeight:

&nbsp;         type: number

&nbsp;         description: The calculated dimensional weight for the package based on user provided dimensions. The greater of dimWeight and weight will be used to calculated the rate.

&nbsp;         format: double

&nbsp;         example: 5

&nbsp;       fees:

&nbsp;         type: array

&nbsp;         description: The fees associated with the package.

&nbsp;         xml:

&nbsp;           wrapped: true

&nbsp;         items:

&nbsp;           type: object

&nbsp;           properties:

&nbsp;             name:

&nbsp;               type: string

&nbsp;               description: The name of the fee.

&nbsp;             SKU:

&nbsp;               type: string

&nbsp;               description: The pricing SKU for the fee.

&nbsp;             price:

&nbsp;               type: number

&nbsp;               description: The price for the fee.

&nbsp;               format: double

&nbsp;           xml:

&nbsp;             name: fee

&nbsp;       startDate:

&nbsp;         type: string

&nbsp;         description: Effective start date of the rate.

&nbsp;         format: date

&nbsp;         example: "2021-07-16"

&nbsp;       endDate:

&nbsp;         type: string

&nbsp;         description: Effective end date of the rate.  If blank the rate doesn't have an end date as of yet.

&nbsp;         pattern: '^$|^\[0-9]{4}-\[0-9]{2}-\[0-9]{2}$'

&nbsp;         example: "2021-07-16"

&nbsp;       mailClass:

&nbsp;         type: string

&nbsp;         description: The mail class of the price.

&nbsp;       zone:

&nbsp;         type: string

&nbsp;         description: Indicates the price group for a given `destinationCountryCode`, `mailClass`, `mailingDate`, and `rateIndicator`.

&nbsp;         example: "01"

&nbsp;       processingCategory:

&nbsp;         type: string

&nbsp;         description: |

&nbsp;           Processing category for the provided rate, this value can be used in the international labels API to ensure the provided rate is applied.



&nbsp;           \* `CARDS` - Cards, translates to PTR code `0`

&nbsp;           \* `LETTERS` - Letters, translates to PTR code `1`

&nbsp;           \* `FLATS` - Flats, translates to PTR code `2`

&nbsp;           \* `MACHINABLE` - Machinable Parcel, translates to PTR code `3`

&nbsp;           \* `IRREGULAR` - Irregular Parcel, translates to PTR code `4` - This option is deprecated in favor of `NONSTANDARD` and will no longer be returned as of 01/19/2025.

&nbsp;           \* `NON\_MACHINABLE` - Non-machinable parcel, translates to PTR code `5` - This option is deprecated in favor of `NONSTANDARD` and will no longer be returned as of 01/19/2025.

&nbsp;           \* `NONSTANDARD` - Nonstandard Parcel, translates to PTR code `5`

&nbsp;           \* `CATALOGS` - Catalogs, translates to PTR code `C`

&nbsp;           \* `OPEN\_AND\_DISTRIBUTE` - Open and Distribute, translates to PTR code `O`

&nbsp;           \* `RETURNS` - Returns, translates to PTR code `R`

&nbsp;           \* `SOFT\_PACK\_MACHINABLE` - Soft Pack Machinable, translates to PTR code `S`

&nbsp;           \* `SOFT\_PACK\_NON\_MACHINABLE` - Soft Package Non-machinable, translates to PTR code `T`

&nbsp;         enum:

&nbsp;           - CARDS

&nbsp;           - LETTERS

&nbsp;           - FLATS

&nbsp;           - MACHINABLE

&nbsp;           - IRREGULAR

&nbsp;           - NON\_MACHINABLE

&nbsp;           - NONSTANDARD

&nbsp;           - CATALOGS

&nbsp;           - OPEN\_AND\_DISTRIBUTE

&nbsp;           - RETURNS

&nbsp;           - SOFT\_PACK\_MACHINABLE

&nbsp;           - SOFT\_PACK\_NON\_MACHINABLE

&nbsp;         example: MACHINABLE

&nbsp;       rateIndicator:

&nbsp;         type: string

&nbsp;         description: Two-digit rate indicator code for the provided rate, this value can be used in the international labels API to ensure the provided rate is applied.

&nbsp;         example: "SP"

&nbsp;       destinationEntryFacilityType:

&nbsp;         type: string

&nbsp;         description: |

&nbsp;           Destination Entry Facility type for the provided rate, this value can be used in the international labels API to ensure the provided rate is applied.



&nbsp;           \* `NONE` - None, translates to PTR code `N`

&nbsp;           \* `INTERNATIONAL\_SERVICE\_CENTER` - International Service Center, translates to PTR code `I`

&nbsp;         enum:

&nbsp;           - NONE

&nbsp;           - INTERNATIONAL\_SERVICE\_CENTER

&nbsp;         example: INTERNATIONAL\_SERVICE\_CENTER

&nbsp;       warnings:

&nbsp;         $ref: '#/components/schemas/WarningsList'

&nbsp;       productName:

&nbsp;         type: string

&nbsp;         description: A business friendly name for a product that can be displayed to a customer on a shipping portal

&nbsp;         example: Priority Mail Express International

&nbsp;       productDefinition:

&nbsp;         type: string

&nbsp;         description: A business friendly description for a product that can be displayed to a customer on a shipping portal

&nbsp;         example: Fastest international service with date-certain delivery to multiple countries.

&nbsp;     additionalProperties: false

&nbsp;     description: Informative details about the price.

&nbsp;     xml:

&nbsp;       name: rate

&nbsp;   ErrorMessage:

&nbsp;     title: Error

&nbsp;     type: object

&nbsp;     properties:

&nbsp;       apiVersion:

&nbsp;         type: string

&nbsp;         description: The version of the API that was used and that raised the error.

&nbsp;       error:

&nbsp;         type: object

&nbsp;         properties:

&nbsp;           code:

&nbsp;             type: string

&nbsp;             description: The error status code that has been returned in response to the request.

&nbsp;           message:

&nbsp;             type: string

&nbsp;             description: A human-readable message describing the error.

&nbsp;           errors:

&nbsp;             type: array

&nbsp;             description: Additional information regarding the error that was received.

&nbsp;             items:

&nbsp;               type: object

&nbsp;               properties:

&nbsp;                 status:

&nbsp;                   type: string

&nbsp;                   description: The status code response returned to the client.

&nbsp;                 code:

&nbsp;                   type: string

&nbsp;                   description: An internal subordinate code used for error diagnosis.

&nbsp;                 title:

&nbsp;                   type: string

&nbsp;                   description: A human-readable title that identifies the error.

&nbsp;                 detail:

&nbsp;                   type: string

&nbsp;                   description: A human-readable description of the error that occurred.

&nbsp;                 source:

&nbsp;                   type: object

&nbsp;                   properties:

&nbsp;                     parameter:

&nbsp;                       type: string

&nbsp;                       description: The input in the request which caused an error.

&nbsp;                     example:

&nbsp;                       type: string

&nbsp;                       description: An example of a valid value for the input parameter.

&nbsp;                   additionalProperties: true

&nbsp;                   description: The element that is suspected of originating the error.  Helps to pinpoint the problem.

&nbsp;               additionalProperties: true

&nbsp;         additionalProperties: true

&nbsp;         description: The high-level error that has occurred as indicated by the status code.

&nbsp;     additionalProperties: true

&nbsp;     description: Standard error message response.

&nbsp;   LetterRatesOption:

&nbsp;     title: Letter Rates Query Result

&nbsp;     type: object

&nbsp;     properties:

&nbsp;       totalBasePrice:

&nbsp;         type: number

&nbsp;         description: "The total price, including the rate and fees."

&nbsp;         format: double

&nbsp;         example: 0.63

&nbsp;       rates:

&nbsp;         type: array

&nbsp;         description: List of rate details, including SKU, description and rate ingredients

&nbsp;         xml:

&nbsp;           wrapped: true

&nbsp;         items:

&nbsp;           $ref: '#/components/schemas/LettersRateDetails'

&nbsp;     additionalProperties: false

&nbsp;     description: The prices that match the search criteria.

&nbsp;     xml:

&nbsp;       name: rateOption

&nbsp;   LettersRateDetails:

&nbsp;     title: Letter Rates

&nbsp;     type: object

&nbsp;     description: Rate Details for the request letter search criteria.

&nbsp;     allOf:

&nbsp;       - $ref: '#/components/schemas/LetterRateDetail'

&nbsp;       - type: object

&nbsp;         properties:

&nbsp;           warnings:

&nbsp;             type: array

&nbsp;             description: List of warnings

&nbsp;             xml:

&nbsp;               wrapped: true

&nbsp;             items:

&nbsp;               type: string

&nbsp;               xml:

&nbsp;                 name: warning

&nbsp;   LetterRateDetail:

&nbsp;     title: Letter Rate Details

&nbsp;     type: object

&nbsp;     properties:

&nbsp;       SKU:

&nbsp;         type: string

&nbsp;         description: The stock keeping unit for the designated rate.

&nbsp;         example: DPXX0XXXXX07200

&nbsp;       description:

&nbsp;         type: string

&nbsp;         description: The description of the price.

&nbsp;         example: "First Class Letter Metered"

&nbsp;       priceType:

&nbsp;         type: string

&nbsp;         description: The type of price type applied (Retail).

&nbsp;         enum:

&nbsp;           - RETAIL

&nbsp;       price:

&nbsp;         type: number

&nbsp;         description: The postage price.

&nbsp;         format: double

&nbsp;         example: 3.35

&nbsp;       weight:

&nbsp;         type: number

&nbsp;         description: The calculated weight for the package based on user input.  The greater of dimWeight and weight will be used to calculated the rate.

&nbsp;         format: double

&nbsp;         example: 5

&nbsp;       fees:

&nbsp;         type: array

&nbsp;         description: The fees associated with the package.

&nbsp;         xml:

&nbsp;           wrapped: true

&nbsp;         items:

&nbsp;           type: object

&nbsp;           properties:

&nbsp;             name:

&nbsp;               type: string

&nbsp;               description: The name of the fee.

&nbsp;             SKU:

&nbsp;               type: string

&nbsp;               description: The pricing SKU for the fee.

&nbsp;             price:

&nbsp;               type: number

&nbsp;               description: The price for the fee.

&nbsp;               format: double

&nbsp;           xml:

&nbsp;             name: fee

&nbsp;       startDate:

&nbsp;         type: string

&nbsp;         description: Effective start date of the rate.

&nbsp;         format: date

&nbsp;         example: "2021-07-16"

&nbsp;       endDate:

&nbsp;         type: string

&nbsp;         description: Effective end date of the rate.  If blank the rate doesn't have an end date as of yet.

&nbsp;         pattern: '^$|^\[0-9]{4}-\[0-9]{2}-\[0-9]{2}$'

&nbsp;         example: "2021-07-16"

&nbsp;       mailClass:

&nbsp;         type: string

&nbsp;         description: The mail class of the price.

&nbsp;         enum:

&nbsp;           - FIRST-CLASS\_MAIL

&nbsp;       extraServices:

&nbsp;         type: array

&nbsp;         description: A list of Extra Services to be included in the total rates search. If no extra services are specified all applicable extra services for the mail class will be returned.

&nbsp;         items:

&nbsp;           type: object

&nbsp;           properties:

&nbsp;             SKU:

&nbsp;               $ref: '#/components/schemas/SKU'

&nbsp;             price:

&nbsp;               $ref: '#/components/schemas/price'

&nbsp;             priceType:

&nbsp;               $ref: '#/components/schemas/internationalPriceType'

&nbsp;             extraService:

&nbsp;               type: string

&nbsp;               description: Extra Service Code

&nbsp;               example: "930"

&nbsp;             name:

&nbsp;               $ref: '#/components/schemas/ExtraServiceName'

&nbsp;             warnings:

&nbsp;               $ref: '#/components/schemas/WarningsList'

&nbsp;       zone:

&nbsp;         type: string

&nbsp;         description: Indicates the price group for a given `destinationCountryCode` and `mailingDate`.

&nbsp;         example: "00"

&nbsp;     additionalProperties: true

&nbsp;     description: Informative details about the price.

&nbsp;     xml:

&nbsp;       name: rate

&nbsp;   originZIPCode:

&nbsp;     pattern: "^\\\\d{5}(?:\[-\\\\s]\\\\d{4})?$"

&nbsp;     type: string

&nbsp;     description: The originating ZIP code for the package.

&nbsp;   weightPounds:

&nbsp;     type: number

&nbsp;     description: The calculated weight for the package based on user input.  The greater of dimWeight and weight will be used to calculated the rate. Weight unit of measurement is in pounds.

&nbsp;     format: double

&nbsp;     example: 5

&nbsp;   weightOunces:

&nbsp;     type: number

&nbsp;     description: The calculated weight for the package based on user input.  The greater of dimWeight and weight will be used to calculated the rate. Weight unit of measurement is in ounces.

&nbsp;     format: double

&nbsp;     example: 5

&nbsp;   length:

&nbsp;     type: number

&nbsp;     description: The package length in inches.  The maximum dimension is always length.

&nbsp;     format: double

&nbsp;   width:

&nbsp;     type: number

&nbsp;     description: The package width in inches.  The second longest dimension is always width.

&nbsp;     format: double

&nbsp;   height:

&nbsp;     type: number

&nbsp;     description: The package height in inches.

&nbsp;     format: double

&nbsp;   internationalPriceType:

&nbsp;     type: string

&nbsp;     description: Price type can be  \* 'RETAIL' \* 'COMMERCIAL' \* 'COMMERCIAL\_BASE' \* 'COMMERCIAL\_PLUS' \* 'CONTRACT'

&nbsp;     enum:

&nbsp;     - RETAIL

&nbsp;     - COMMERCIAL

&nbsp;     - COMMERCIAL\_BASE

&nbsp;     - COMMERCIAL\_PLUS

&nbsp;     - CONTRACT

&nbsp;   mailingDate:

&nbsp;     type: string

&nbsp;     description: 'The date the package or letter/flat will be mailed. The mailing date may be today plus 0 to 7 days in advance.        '

&nbsp;     format: date

&nbsp;     example: "2021-07-01"

&nbsp;   SKU:

&nbsp;     type: string

&nbsp;     description: The stock keeping unit for the designated rate.

&nbsp;     example: DPXX0XXXXX07200

&nbsp;   price:

&nbsp;     type: number

&nbsp;     description: The postage rate.

&nbsp;     format: double

&nbsp;     example: 3.35

&nbsp;   RateOptions:

&nbsp;     title: Base Rates Query Result

&nbsp;     type: array

&nbsp;     additionalProperties: false

&nbsp;     description: The prices that match the search criteria.

&nbsp;     xml:

&nbsp;       name: rateOptions

&nbsp;     items:

&nbsp;       $ref: '#/components/schemas/RateOption'

&nbsp;   DestinationCountryCode:

&nbsp;     title: Destination Country Code

&nbsp;     pattern: ^\[A-Z]{2}$

&nbsp;     type: string

&nbsp;     description: The ISO 3166-1 alpha-2 code representing the shipping destination.

&nbsp;     example: "CA"

&nbsp;   WarningsList:

&nbsp;     title: Warnings

&nbsp;     type: array

&nbsp;     description: A list of warnings associated with the rate calculation.

&nbsp;     xml:

&nbsp;       wrapped: true

&nbsp;     items:

&nbsp;       type: object

&nbsp;       properties:

&nbsp;         warningCode:

&nbsp;           type: string

&nbsp;           description: Code representing the type of warning.

&nbsp;           example: "001"

&nbsp;         warningDescription:

&nbsp;           type: string

&nbsp;           description: Description of the warning.

&nbsp;           example: "Contract rate not found for request. Published rate returned."

&nbsp;       xml:

&nbsp;         name: warning

&nbsp;   TotalRatesRequestLandedCostItem:

&nbsp;     title: Delivery Duties, Taxes, and Fees Item

&nbsp;     description: 'When `requestDutiesTaxesFees` is true at least one item is required.'

&nbsp;     type: object

&nbsp;     required:

&nbsp;       - itemId

&nbsp;       - itemValue

&nbsp;       - itemQuantity

&nbsp;     properties:

&nbsp;       itemId:

&nbsp;         type: string

&nbsp;         maxLength: 20

&nbsp;         minLength: 1

&nbsp;         description: 'A user-provided item identifier. The itemId is echoed in the response to correlate duties and taxes to this item.'

&nbsp;         pattern: "^\\\\w{1,20}$"

&nbsp;         example: "001"

&nbsp;       itemValue:

&nbsp;         maximum: 999999.99

&nbsp;         minimum: 0.01

&nbsp;         type: number

&nbsp;         format: float

&nbsp;         description: 'The value of the item.'

&nbsp;       itemQuantity:

&nbsp;         minimum: 1

&nbsp;         type: number

&nbsp;         description: 'The quantity of the item.'

&nbsp;         example: 3

&nbsp;       weight:

&nbsp;         minimum: 0.001

&nbsp;         type: number

&nbsp;         description: The calculated weight for each individual item within a quantity based on user input.

&nbsp;         format: double

&nbsp;         example: 5

&nbsp;       countryOfOrigin:

&nbsp;         pattern: "\[A-Z]{2}"

&nbsp;         type: string

&nbsp;         description: 'A two digit Alpha Country Code defined by ISO representing where the item is from.'

&nbsp;         example: 'CA'

&nbsp;       HSTariffNumber:

&nbsp;         maxLength: 14

&nbsp;         minLength: 6

&nbsp;         type: string

&nbsp;         description: 'The HS tariff number is based on the Harmonized Commodity Description and Coding System developed by the World Customs Organization.  The value should follow the regular expression pattern: `^\\.\*(?:\[A-Za-z\\d]\\.\*){6,14}$`.  For more information, see: \[https://hts.usitc.gov/current](https://hts.usitc.gov/current).'

&nbsp; examples:

&nbsp;   BaseRatesSearchResponseExample:

&nbsp;     summary: Example Base Rates Search Response

&nbsp;     description: An example of a base rates search response.

&nbsp;     value:

&nbsp;       rates:

&nbsp;         - mailClass: PRIORITY\_MAIL\_INTERNATIONAL

&nbsp;           priceType: COMMERCIAL\_BASE

&nbsp;           zone: "01"

&nbsp;           rateIndicator: SP

&nbsp;           processingCategory: MACHINABLE

&nbsp;           dimWeight: 0

&nbsp;           fees: \[ ]

&nbsp;           warnings: \[ ]

&nbsp;           startDate: "2025-10-05"

&nbsp;           endDate: ""

&nbsp;           SKU: IPXX0XXXXB01040

&nbsp;           price: 50.6

&nbsp;           destinationEntryFacilityType: NONE

&nbsp;           weight: 4

&nbsp;           description: Priority Mail International Machinable Single-piece

&nbsp;       totalBasePrice: 50.6

&nbsp;   ExtraServiceRatesSearchResponseExample:

&nbsp;       summary: Example Extra Service Rates Search Response

&nbsp;       description: An example of an extra service rates search response.

&nbsp;       value:

&nbsp;         extraServices:

&nbsp;           - SKU: IXIE0XXXXCX0400

&nbsp;             priceType: COMMERCIAL

&nbsp;             price: 15.0

&nbsp;             extraService: 930

&nbsp;             name: Insurance <= $500

&nbsp;             warnings:

&nbsp;               - warningCode: "001"

&nbsp;                 warningDescription: Contract rate not found for request. Published rate returned.

&nbsp;   BaseRatesListSearchResponseExample:

&nbsp;       summary: Example Base Rates List Search Response

&nbsp;       description: An example of a base rates list search response.

&nbsp;       value:

&nbsp;         rateOptions:

&nbsp;           - rates:

&nbsp;               - mailClass: PRIORITY\_MAIL\_EXPRESS\_INTERNATIONAL

&nbsp;                 priceType: COMMERCIAL\_BASE

&nbsp;                 dimWeight: 0

&nbsp;                 zone: "01"

&nbsp;                 rateIndicator: PA

&nbsp;                 processingCategory: FLATS

&nbsp;                 fees: \[ ]

&nbsp;                 startDate: "2025-10-05"

&nbsp;                 endDate: ""

&nbsp;                 productName: ""

&nbsp;                 productDefinition: ""

&nbsp;                 SKU: IEXX0XXXXB01010

&nbsp;                 price: 59.99

&nbsp;                 weight: 1

&nbsp;                 destinationEntryFacilityType: INTERNATIONAL\_SERVICE\_CENTER

&nbsp;                 description: Priority Mail Express International ISC Single-piece

&nbsp;             totalBasePrice: 59.99

&nbsp;           - rates:

&nbsp;               - mailClass: PRIORITY\_MAIL\_EXPRESS\_INTERNATIONAL

&nbsp;                 priceType: COMMERCIAL\_BASE

&nbsp;                 dimWeight: 0

&nbsp;                 zone: "01"

&nbsp;                 rateIndicator: FP

&nbsp;                 processingCategory: FLATS

&nbsp;                 fees: \[ ]

&nbsp;                 startDate: "2025-10-05"

&nbsp;                 endDate: ""

&nbsp;                 productName: ""

&nbsp;                 productDefinition: ""

&nbsp;                 SKU: IEFE2XXXXB01040

&nbsp;                 price: 56.1

&nbsp;                 weight: 1

&nbsp;                 destinationEntryFacilityType: INTERNATIONAL\_SERVICE\_CENTER

&nbsp;                 description: Priority Mail Express International ISC Padded Flat Rate Envelope

&nbsp;             totalBasePrice: 56.1

&nbsp;   TotalRatesSearchResponseExample:

&nbsp;     summary: Example Total Rates Response

&nbsp;     description: An example of a total rates response.

&nbsp;     value:

&nbsp;       rateOptions:

&nbsp;         - totalBasePrice: 73.24

&nbsp;           totalPrice: 73.24

&nbsp;           rates:

&nbsp;             - description: Priority Mail International Machinable ISC Large Flat Rate Box

&nbsp;               priceType: COMMERCIAL\_BASE

&nbsp;               price: 73.24

&nbsp;               weight: 1.2

&nbsp;               dimWeight: 0.0

&nbsp;               fees: \[ ]

&nbsp;               startDate: "2025-10-05"

&nbsp;               endDate: ""

&nbsp;               mailClass: PRIORITY\_MAIL\_INTERNATIONAL

&nbsp;               zone: "01"

&nbsp;               productName: ""

&nbsp;               productDefinition: ""

&nbsp;               processingCategory: MACHINABLE

&nbsp;               rateIndicator: PL

&nbsp;               destinationEntryFacilityType: INTERNATIONAL\_SERVICE\_CENTER

&nbsp;               SKU: IPFB0XXXXB01200

&nbsp;           extraServices:

&nbsp;             - extraService: "930"

&nbsp;               name: Insurance <= $500

&nbsp;               priceType: COMMERCIAL

&nbsp;               price: 0.00

&nbsp;               warnings:

&nbsp;                 - warningCode: "001"

&nbsp;                   warningDescription: Contract rate not found for request. Published rate returned.

&nbsp;               SKU: IXIP0XXXXCX0200

&nbsp;         - totalBasePrice: 58.06

&nbsp;           totalPrice: 58.06

&nbsp;           rates:

&nbsp;             - description: Priority Mail International Machinable ISC Medium Flat Rate Box

&nbsp;               priceType: COMMERCIAL\_BASE

&nbsp;               price: 58.06

&nbsp;               weight: 1.2

&nbsp;               dimWeight: 0.0

&nbsp;               fees: \[ ]

&nbsp;               startDate: "2025-10-05"

&nbsp;               endDate: ""

&nbsp;               mailClass: PRIORITY\_MAIL\_INTERNATIONAL

&nbsp;               zone: "01"

&nbsp;               productName: ""

&nbsp;               productDefinition: ""

&nbsp;               processingCategory: MACHINABLE

&nbsp;               rateIndicator: FB

&nbsp;               destinationEntryFacilityType: INTERNATIONAL\_SERVICE\_CENTER

&nbsp;               SKU: IPFB1XXXXB01200

&nbsp;           extraServices:

&nbsp;             - extraService: "930"

&nbsp;               name: Insurance <= $500

&nbsp;               priceType: COMMERCIAL

&nbsp;               price: 0.00

&nbsp;               warnings:

&nbsp;                 - warningCode: "001"

&nbsp;                   warningDescription: Contract rate not found for request. Published rate returned.

&nbsp;               SKU: IXIP0XXXXCX0200

&nbsp;         - totalBasePrice: 29.66

&nbsp;           totalPrice: 29.66

&nbsp;           rates:

&nbsp;             - description: Priority Mail International Machinable ISC Padded Flat Rate Envelope

&nbsp;               priceType: COMMERCIAL\_BASE

&nbsp;               price: 29.66

&nbsp;               weight: 1.2

&nbsp;               dimWeight: 0.0

&nbsp;               fees: \[ ]

&nbsp;               startDate: "2025-10-05"

&nbsp;               endDate: ""

&nbsp;               mailClass: PRIORITY\_MAIL\_INTERNATIONAL

&nbsp;               zone: "01"

&nbsp;               productName: ""

&nbsp;               productDefinition: ""

&nbsp;               processingCategory: MACHINABLE

&nbsp;               rateIndicator: FP

&nbsp;               destinationEntryFacilityType: INTERNATIONAL\_SERVICE\_CENTER

&nbsp;               SKU: IPFE2XXXXB01040

&nbsp;           extraServices:

&nbsp;             - extraService: "930"

&nbsp;               name: Insurance <= $500

&nbsp;               priceType: COMMERCIAL

&nbsp;               price: 0.00

&nbsp;               warnings:

&nbsp;                 - warningCode: "001"

&nbsp;                   warningDescription: Contract rate not found for request. Published rate returned.

&nbsp;               SKU: IXIP0XXXXCX0200

&nbsp;         - totalBasePrice: 44.18

&nbsp;           totalPrice: 44.18

&nbsp;           rates:

&nbsp;             - description: Priority Mail International ISC Single-piece

&nbsp;               priceType: COMMERCIAL\_BASE

&nbsp;               price: 44.18

&nbsp;               weight: 1.2

&nbsp;               dimWeight: 0.0

&nbsp;               fees: \[ ]

&nbsp;               startDate: "2025-10-05"

&nbsp;               endDate: ""

&nbsp;               mailClass: PRIORITY\_MAIL\_INTERNATIONAL

&nbsp;               zone: "01"

&nbsp;               productName: ""

&nbsp;               productDefinition: ""

&nbsp;               processingCategory: FLATS

&nbsp;               rateIndicator: SP

&nbsp;               destinationEntryFacilityType: INTERNATIONAL\_SERVICE\_CENTER

&nbsp;               SKU: IPXX0XXXXB01020

&nbsp;           extraServices:

&nbsp;             - extraService: "930"

&nbsp;               name: Insurance <= $500

&nbsp;               priceType: COMMERCIAL

&nbsp;               price: 0.00

&nbsp;               warnings:

&nbsp;                 - warningCode: "001"

&nbsp;                   warningDescription: Contract rate not found for request. Published rate returned.

&nbsp;               SKU: IXIP0XXXXCX0200

&nbsp;         - totalBasePrice: 44.18

&nbsp;           totalPrice: 44.18

&nbsp;           rates:

&nbsp;             - description: Priority Mail International Machinable ISC Single-piece

&nbsp;               priceType: COMMERCIAL\_BASE

&nbsp;               price: 44.18

&nbsp;               weight: 1.2

&nbsp;               dimWeight: 0.0

&nbsp;               fees: \[ ]

&nbsp;               startDate: "2025-10-05"

&nbsp;               endDate: ""

&nbsp;               mailClass: PRIORITY\_MAIL\_INTERNATIONAL

&nbsp;               zone: "01"

&nbsp;               productName: ""

&nbsp;               productDefinition: ""

&nbsp;               processingCategory: MACHINABLE

&nbsp;               rateIndicator: SP

&nbsp;               destinationEntryFacilityType: INTERNATIONAL\_SERVICE\_CENTER

&nbsp;               SKU: IPXX0XXXXB01020

&nbsp;           extraServices:

&nbsp;             - extraService: "930"

&nbsp;               name: Insurance <= $500

&nbsp;               priceType: COMMERCIAL

&nbsp;               price: 0.00

&nbsp;               warnings:

&nbsp;                 - warningCode: "001"

&nbsp;                   warningDescription: Contract rate not found for request. Published rate returned.

&nbsp;               SKU: IXIP0XXXXCX0200

&nbsp;   LetterRatesSearchResponseExample:

&nbsp;       summary: Example Letter Rates Response

&nbsp;       description: An example of a letter rates response.

&nbsp;       value:

&nbsp;         totalBasePrice: 30.64

&nbsp;         rates:

&nbsp;           - SKU: IFXL0XXXXR09010

&nbsp;             description: First Class Letter Metered

&nbsp;             priceType: RETAIL

&nbsp;             price: 1.7

&nbsp;             weight: 1

&nbsp;             fees:

&nbsp;               - name: Nonmachinable letter fee

&nbsp;                 SKU: IX1F0XXLXRX0000

&nbsp;                 price: 0.49

&nbsp;             startDate: "2025-10-05"

&nbsp;             endDate: ""

&nbsp;             warnings: \[ ]

&nbsp;             mailClass: FIRST-CLASS\_MAIL

&nbsp;             zone: "00"

&nbsp;             extraServices:

&nbsp;               - warnings: \[ ]

&nbsp;                 priceType: RETAIL

&nbsp;                 SKU: IXRF0XXXXRX0000

&nbsp;                 price: 6.7

&nbsp;                 name: Return Receipt

&nbsp;                 extraService: "955"

&nbsp;               - warnings: \[ ]

&nbsp;                 priceType: RETAIL

&nbsp;                 SKU: IXGF0XXXXRX0000

&nbsp;                 price: 21.75

&nbsp;                 name: Registered Mail

&nbsp;                 extraService: "940"

&nbsp; headers:

&nbsp;   WWWAuthenticate:

&nbsp;     description: Hint to the client application which security scheme to authorize a resource request.

&nbsp;     required: false

&nbsp;     schema:

&nbsp;       type: string

&nbsp;       example: "WWW-Authenticate: Bearer realm=\\"https://api.usps.com\\""

&nbsp;   RetryAfter:

&nbsp;     description: Indicate to the client application a time after which they can retry a resource request.

&nbsp;     required: false

&nbsp;     schema:

&nbsp;       type: string

&nbsp;       example: "Retry-After: 30"

&nbsp; securitySchemes:

&nbsp;   OAuth:

&nbsp;     type: oauth2

&nbsp;     description: The specified APIs accept an access token formatted as a JSON Web Token. The relative path to the OAuth2 version 3 API which supplies this access token is provided below for reference.

&nbsp;     flows:

&nbsp;       clientCredentials:

&nbsp;         tokenUrl: /oauth2/v3/token

&nbsp;         scopes:

&nbsp;           international-prices: get prices based on ingredients

&nbsp;       authorizationCode:

&nbsp;         authorizationUrl: /oauth2/v3/authorize

&nbsp;         tokenUrl: /oauth2/v3/token

&nbsp;         scopes:

&nbsp;           international-prices: get prices based on ingredients



