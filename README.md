Es una aplicacion de consola manejada por comandos que ayudara a organizarte tareas.
URL de la pagina del proyecto: https://roadmap.sh/projects/task-tracker

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
4. Configurar ConnectionStrings en appsettings.json.

		"ConnectionStrings": {
        "DefaultConnection": "Server=AUGUSTO\\SQLEXPRESS;Database=BlogApi;Trusted_Connection=True;TrustServerCertificate=True"
        },
   
5. Ejecutar las migraciones



#Uso
1. POST
   	{
	  "title": "My First Blog Post",
	  "content": "This is the content of my first blog post.",
	  "category": "Technology",
	  "tags": ["Tech", "Programming"]
	}
