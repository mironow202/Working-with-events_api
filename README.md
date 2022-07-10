 

# Об API #
*Данная апишка была предназначена для работы с базой данных MS SQL. В ней присутвуют четыре контроллера, каждый из которых 
выполняет свою роль. Так же интрефейс IEventRepository и IRepository для работы с бд.(WizardPatrick - my second account is just ssh connected to this laptop)*

# Фунционал #
*api/HttpGet/*
+ get-all-events - выдаст все мероприятия, которые есть в БД.
+ get-event/{id} - выдаст мероприятие по его id.
+ get-events-by-name/{name} - выдаст мероприятие по его спикеру.

***
*api/HttpPost/*
+ create-event - создаст обьект в БД.
+ create-events - создаст список обьектов в БД.
+ create-event-only-spiker/{spiker}/{description} - создаст обьект по спикеру и описанию. (без FromBody)
 
***
*api/HttpDelete/*
+ delete-evnt/{id} - удалит обьект по его id.
+ delete-event-by-name/{name} - удалит обьект по его имени.
 
***
*api/HttpPut/*
+ edit-event - обновит обьект.

 
 
 
