Es una simple API RESTful con las operaciones basicas de CRUD para una plataforma de blog personal.
URL de la pagina del proyecto: https://roadmap.sh/projects/blogging-platform-api

# Requisitos

- Crear un nuevo post en el blog.
- Actualizar un post existente.
- Eliminar un post existente.
- Obtener todos los posts.
- Obtener un post solo.
- Filtrar post por termino de busqueda.

# Instalacion
Para usar la aplicacion, seguir los siuientes pasos:
1. Clonar el repositorio:

        git clone https://github.com/chirogod/BlogApi.git 

2. Navegar a la raiz del proyecto

		cd BlogApi

3. Abrir en IDE de preferencia.
4. Configurar ConnectionStrings a su servidro en appsettings.json.

		"ConnectionStrings": {
        "DefaultConnection": "Server=ServerName;Database=DbName;Trusted_Connection=True;TrustServerCertificate=True"
        },
   
5. Ejecutar las migraciones de EF Core correspondientes asegurandose de tener las herramientas instaladas.

#GET /api/post

   	Obtiene todos los posts.

#GET /api/post/{id}

   	Obtiene el post con ese id.

#GET /api/post?term=tech

   	Obtiene todos los post con ese termino de busqueda en su titulo, descripcion o categoria.

#POST /api/post

   	{
	  "title": "My First Blog Post",
	  "content": "This is the content of my first blog post.",
	  "category": "Technology",
	  "tags": ["Tech", "Programming"]
	}

#PUT /api/post/{id}

   	{
	  "title": "My First Blog Post Edited",
	  "content": "This is the edited content of my first blog post.",
	  "category": "Technology edited",
	  "tags": ["Tech edited", "Programming edited"]
	}

#DELETE /api/post/{id}
