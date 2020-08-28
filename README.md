# MasivianAssessment
Masivian junior assessment

LA BASE DE DATOS EN MEMORIA DEBE ESTAR INICIADA Y CONFIGURADA EN 127.0.0.1:6379

<img src="https://user-images.githubusercontent.com/53131207/91589796-f7ddfd00-e91f-11ea-9b7a-7c980ce24bba.jpg"/>

AL INICIAR EL PROYECTO DESDE MVS SE EJECUTARA DESDE SWAGGER 

<img src="https://user-images.githubusercontent.com/53131207/91589805-fad8ed80-e91f-11ea-99aa-5e4a7bdf20f8.jpg"/>

A CONTINUACION SE PUEDEN REALIZAR LAS PETICIONES CORRESPONDIENTES

--CREATE ROULETTE "Creara ruletas indicando el ID, si el ID existe retornara un 0 como respuesta."
<img src="https://user-images.githubusercontent.com/53131207/91589577-90c04880-e91f-11ea-969f-3cf7f5907263.gif"/>

--OPEN ROULETTE "Abrira la ruleta para poder apostar en ella, si la ruleta no esta abierta no se permiten apuestas. Esta peticion agrega la fecha de apertura de la ruleta."
<img src="https://user-images.githubusercontent.com/53131207/91589737-e1d03c80-e91f-11ea-9bc4-2ade2dacd612.gif"/>

--CREATE ROULETTE BET "Se reciben apuestas de los usuarios a las ruletas abiertas."

<img src="https://user-images.githubusercontent.com/53131207/91589723-dc72f200-e91f-11ea-956a-c3583855dc88.gif"/>

--CLOSE ROULETTE "Cierra la ruleta, se agrega fecha de cierre y se muestra una lista de apuestas realizadas a la ruleta"

<img src="https://user-images.githubusercontent.com/53131207/91589744-e4329680-e91f-11ea-8066-29e2f051b1b6.gif"/>

//GET ROULETTES "Envia un listado de las ruletas creadas y su estado"

<img src="https://user-images.githubusercontent.com/53131207/91589752-e694f080-e91f-11ea-9be5-bd4b8f7e9536.gif"/>

