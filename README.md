# jwt-info
Simple JWT decoding for client side, without external libraries.

## Usage

When receiving a JWT from an authorization service, the client has access to the content of the token.
The data in the token can be used to show/or hide parts of a user interface. If the 'exp' parameter
is provided, the Expiration date is set. This can be used to initialize a token refresh. 

A sample token can be found at: http://JWT.io

~~~~

var jwt="eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9."
  + "eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ."
  + "SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c";

var tokenInfo = jwt.JwtInformation();
if (!tokenInfo.Success){
  // token is not valid
}

~~~~
