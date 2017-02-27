# WebAPI för Todo-app

## Api

    POST /todo 
    {
        description: '',
        start: Date(),
        due: Date() 
    }
    200, { id: 0 }
    500, InternalServerError

    GET /todo
    200, {
        todos: [
            {
                id: 0,
                description: '',
                start: Date(),
                due: Date()            
            },
            {
                id: 0,
                description: '',
                start: Date(),
                due: Date()            
            },
        ]
    }

    GET /todo/:id 
    200, {
        id: 0,
        description: '',
        start: Date(),
        due: Date()   
    }
    404, NotFound
    500, Internal Server Error


    DELETE /todo/:id
    204, NoContent
    404, NotFound
    500, InternalServerError


    PUT /todo/:id
    {
        description: '',
        start: Date(),
        due: Date() 
    }

## Utökningar

- Autentisering (passwordless)
- Filtrering
- Projekt
- Exportering