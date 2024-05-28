# HTTP Background
***Hypertext Transfer Protocol (HTTP)*** is a client-server protocol. This means the client or consumer must initiate the communication. 
 
Information is transferred via multiple messages- it's akin to the way we send letters. 
 
The HTTP protocol is part of the application layer and thus requires some underlying communication protocol to transmit data- that protocol is TCP. 
 
# HTTP Requests
HTTP Requests are composed of: 
- Verb
    - Indicates the executing HTTP method.
- URI
    - Specifies the endpoint where the resource is located.
- HTTP Version.
- Request Header
    - META-DATA (information) of the Request as key-value pairs such as format supported by the client, browser type, etc.
- Request Body
    - Message content or resource representation.
    
 
# HTTP Responses
- HTTP Response
    - Response Code
    - 200 (OK), 403 (Forbidden), 404 (Not Found), 500 (Internal Error), etc.
- HTTP Version.
- Response Header
    - META-DATA for the Response such as: content length, content type, date, etc.
- Response Body
    - Some kind of payload in the case where HTTP is used in the context of a RESTful service then the body is a resource representation. 


 
# Verbs 
HTTP request verbs or methods indicate the action that a client hopes to perform. 
 
Characteristics of requests:
(Basically, a request either is or isn't each of these) 
- idempotent
    - A request method is considered idempotent if the intended effect on the server of multiple identical requests with that method is the same as the effect for a single such request.
- safe
    - doesn't alter the server's state
    - read-only
- cacheable
    - Determines if there is a chance the response to the corresponding method can be cached 
- allowed in HTML forms
- request has a body 

<img src = "https://dz2cdn1.dzone.com/storage/temp/10353600-article1-eng.png">

- Find additional verbs [here](https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods)

# Status Codes
- Informational responses (100–199)

- Successful responses (200–299)

- Redirects (300–399)

- Client errors (400–499)

- Server errors (500–599)

- Further Breakdown of Status Codes [here](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status)

# Headers

HTTP headers let the client and the server pass additional information with an HTTP request or response. Think META-DATA about the msg.

- [Request Headers Example](https://developer.mozilla.org/en-US/docs/Glossary/Request_header)


- [Response Headers Example](https://developer.mozilla.org/en-US/docs/Glossary/Response_header)

# Stateless

Even though multiple requests can be sent over the same HTTP connection, the server does not attach any special meaning to their arriving over the same socket. That is solely a performance thing, intended to minimize the time/bandwidth that'd otherwise be spent reestablishing a connection for each request.

As far as HTTP is concerned, they are all still separate requests and must contain enough information on their own to fulfill the request. That is the essence of "statelessness". 

Requests will not be associated with each other UNLESS  there is some shared info the server knows about, which in most cases is a session ID in a cookie.

# Data Interchange Format: XML vs. JSON

- JSON and XML fulfil a similar purpose of organizing complex data in an understandable and readable format to various APIs (Application Programming Interfaces) and programming languages

- This type of technology is essential because structuring the data is what allows us to share it successfully.

## XML (Extensible Markup Language)
 
- XML is extensible. It lets you define your own tags, the order in which they occur, and how they should be processed or displayed. Another way to think about extensibility is to consider that XML allows all of us to extend our notion of what a document is: it can be a file that lives on a file server, or it can be a transient piece of data that flows between two computer systems (as in the case of Web Services).

## JSON (JavaScript Object Notation)

- JSON is language-independent (just like XML), meaning you can use it with any programming language.

- File size is smaller

- JSON is compact and very easy to read, the files look cleaner and more organized without empty tags and data. Contrarily, XML is often characterized for its complexity and old-fashioned standard due to the tag structure that makes files bigger and harder to read.

<img src ="https://miro.medium.com/max/1268/1*dvI7HYftuM3CokPLB7KTdw.png">

# Client Server Architecture

A client-server architecture is a networking model in which the server provides services to clients to perform user-based tasks. A client and a server are two pieces of software that might be on the same computer, or two different computers that might be separated by miles but connected by the Internet.

**Server** - A server is software designed to process requests and deliver responses to another computer over the internet.

**Client** - A client is a program that runs on a local machine requesting service from the server.
