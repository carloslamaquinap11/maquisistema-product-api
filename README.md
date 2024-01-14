
## Características del proyecto
### Tecnologías utilizadas
1. Entity Framework
        Los ORM como Entity Framework o Dapper facilitan el trabajo para realizar operaciones transaccionales fundamentales y la seguridad por medio de consultas parametrizadas y otros mecanismos de seguridad. En este caso se hizo uso

2. NLog
        Se hizo uso de la librería NLog y un archivo de configuración para guardar el registro de los logs.

3. Mockapi.io
        Herramienta que facilitó el uso de una API para la generación de porcentajes de descuento de precios de productos.

4. Documentación oficial de Microsoft
        Siempre es necesario revisar la documentación para corregir código deprecado.

### Domain-Driven Design
El Diseño Orientado al Dominio (DDD) es un enfoque del desarrollo de software que hace hincapié en la importancia de comprender y modelar el dominio de la aplicación. El DDD proporciona un conjunto de principios, patrones y prácticas para ayudar a diseñar e implantar sistemas de software complejos que reflejen con precisión el ámbito empresarial al que están destinados. El objetivo principal de DDD es reducir la distancia entre los ámbitos técnico y empresarial, fomentando la colaboración y el entendimiento compartido.
Para el desarrollo de proyecto se han utilizado las capas:
    1. Product.API
        Capa más externa, donde s exponen los controladores y ejecutan validaciones de los request.
    2. Maquisistema.Application
        Contiene la lógica a desarrollar y unifica a los demás proyectos como recursos para obtener información necesaria.
    3. Maquisistema.Infrastructure
        Contiene los repositorios y servicios externos.
    4. Maquisistema.Domain
        Contiene las entidades propias del negocio.
    5. Maquisistema.Shared
        Contiene los utilitarios que pueden servir durante todo el proyecto.

### Patrones de diseño
1. Patrón CQRS
La segregación de responsabilidades de comandos y consultas es un patrón de diseño que separa las responsabilidades de gestionar la entrada de comandos (operaciones de escritura) y la entrada de consultas (operaciones de lectura) en distintos componentes. La idea principal detrás de CQRS es tener modelos distintos para leer y escribir datos, permitiendo que cada modelo sea optimizado para su caso de uso específico. Este patrón se utiliza a menudo junto con Event Sourcing y Domain-Driven Design.

2. Patrón Mediator
El patrón Mediator es un patrón de diseño de comportamiento que define un objeto (el mediador) que centraliza la comunicación entre varios objetos, permitiéndoles interactuar sin estar directamente acoplados. En lugar de que los objetos se comuniquen entre sí directamente, lo hacen a través del mediador, que facilita y controla el flujo de comunicación.

3. Patrón Repository
El patrón Repository es un patrón de diseño utilizado habitualmente en el desarrollo de software para abstraer el acceso al almacenamiento de datos, como bases de datos o servicios externos. Proporciona una interfaz de alto nivel para acceder a los datos y gestionarlos, desacoplando el código de la aplicación de la implementación del almacenamiento de datos subyacente. Los principales objetivos del patrón de repositorio son centralizar la lógica de acceso a los datos, mejorar la capacidad de mantenimiento y promover una arquitectura más comprobable y escalable.

4. Patrón DTO
 Data Transfer Object (Objeto de Transferencia de Datos), es un patrón de diseño utilizado para encapsular los datos que deben intercambiarse entre diferentes capas o componentes de software. El objetivo principal de los DTO es transferir datos entre subsistemas minimizando el número de llamadas a métodos y reduciendo la cantidad de datos enviados por la red. Los DTO se utilizan a menudo en sistemas distribuidos, como las arquitecturas cliente-servidor, donde es necesario pasar datos entre diferentes capas o niveles.

5. Singleton
El patrón Singleton es un patrón de diseño que pertenece a la categoría de patrones de diseño de creación. Garantiza que una clase sólo tenga una instancia y proporciona un punto de acceso global a esa instancia. El objetivo principal del patrón Singleton es controlar el proceso de instanciación de una clase, asegurándose de que sólo hay una instancia creada y proporcionando una forma de acceder a esa instancia desde cualquier punto de la aplicación.

## SOLID
#### Interface Segregation Principle (ISP)
#### Es uno de los principios SOLID del diseño orientado a objetos. Hace hincapié en que una clase no debe estar obligada a implementar interfaces que no utiliza. En otras palabras, una clase no debe estar obligada a proporcionar implementaciones para métodos que no necesita o utiliza. Tal es el caso del uso de un repositorio genérico y repositorio por la clase Product, donde hay métodos que son específicos para el repositorio ProductRepository pero no tienen correspondencia necesaria con IGenericRepository.

#### Single Responsibility Principle
El principio de responsabilidad única (SRP) es uno de los principios SOLID del diseño orientado a objetos. Establece que una clase debe tener una sola razón para cambiar, lo que significa que una clase debe tener una sola responsabilidad. En otras palabras, una clase debe tener un solo trabajo o función, y debe encapsular esa responsabilidad. Tal es el caso de los CommandHandler y QueryHandler quen tienen la única responsabilidad de manipular el comando o query que tienen asignado.
