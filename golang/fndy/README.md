# Download Service

Implement a service that provides the functionality for downloading and searching for files. The files
that are going to be applications served to end users and internal clients(employees of the company).
The service should work using REST and provide the appropriate endpoints for the operations mentioned.


## Task 1: Download file.

API `GET` `/download?file_identifiers=[{file_identifier}]`

Given a file identifier, the service should be able to find the file and serve it to the client.

### Bonus sub task: Bulk download

Given a list of `file_identifier`, serve all of them at once as one file.
Let's assume the client is not going to abuse the backend by not asking for more than 5 files at once.

## Task 2: Search for files, based on a set of attributes.

API: `GET` `/search?attr1=val1&attr2=val2&...&attrn=valn`

The set of attributes that users can base their search on is the following:

1. Application name - the name of the application requested for download.

    `appName`: `mobile`, `desktop`, `shift_planner`, `service`

2. Operating system - the OS required by the client, searching for the file

    `os`: `macos`, `linux`, `windows`

3. Version - the version of the application requested

    `version`: `1, 2, ..., n`

No attribute is required. If no attributes are specified, the results should be sorted by application name.
For matching application names, it should sort by version and for matching versions, sort by operating system.

Example request:
```json
    {
        "appName": "desktop",
        "os": "macos",
        "version": 3
    }
```

### Bonus sub task: Limit and Pagination

The API should support limiting the response to a specific number of files [1:100], giving it a `limit` parameter.

The API should provide paging, giving the opportunity to fetch the next N or previous N results.
It does not need to support fetching a specific page.

## Requirements
1. The service should be written in either Go, Java, Python or NodeJS.
2. The service should support multiple clients.
3. The service should support adequate logging, preferably structured JSON logging.
4. The service should have basic documentation in the form of a README.md file.
5. Code should be adequately tested and easy to read.


## Bonus tasks
1. Simple authentication.
2. Some form of rate limiting.
3. Means of supporting slow downloaders.
4. Support for downloads that can be paused and resumed.
5. OpenAPI based endpoints.
6. Basic metrics - Request Rate, Errors and Duration
7. Basic tracing
