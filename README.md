OBS:As Consultaspodem ser realizadas em um aplicativo de testar APIs com o PostMan

Exemplo de como compilar: 
Apos Abrir o projeto no Visual Studio Clique em "IIS Express" para compilar o projeto 
Como não tem front end para consumir a API, o navegador irá abrir apenas uma pagina de erro, mas a aplicação ja estara rodando.

Exemplos de Chamadas: 

-JOB:

* Get Jobs : http://localhost:63533/api/Jobs
* Get Job: http://localhost:63533/api/Jobs/{id}
* Post Job: http://localhost:63533/api/Jobs/PostJob
    Exemplo de Post: 
         {
          "id": 15,
          "name": "Job de Teste",
          "active": true,
          "parentJob": {
            "id": 119,
            "name": "teste5",
            "active": true,
            "Tasks": []
          },
          "tasks": [
            {
              "id": 20,
              "name": "First task",
              "weight": 5,
              "completed": true,
              "ParentJobId":19,
              "createdAt": "2015-05-23"
            },
            {
              "id": 21,
              "name": "Second task",
              "weight": 2,
              "completed": false,
              "ParentJobId":15,
              "createdAt": "2017-05-23"
            }
  ]
}
* Put Job: http://localhost:63533/api/Jobs/2
* Delete Job: http://localhost:63533/api/Jobs/DeleteJob/2

-Task:
* Get Tasks: http://localhost:63533/api/Jobs
* Get Task: http://localhost:63533/api/Jobs/{id}
* Post Task: http://localhost:63533/api/Jobs/PostJob
    Exemplo de Post:
             {
              "id": 10,
              "name": "7 task",
              "weight": 9,
              "completed": true,
              "createdAt": "2020-05-28",
              "ParentJobId":"1"
            }
* Put Task: http://localhost:63533/api/Jobs/2
* Delete Task: http://localhost:63533/api/Jobs/DeleteJob/2


Como realizar os testes : 
Onde: Na solution "JobsAPI" o projeto "JobsAPI.Tests"
Clique com um botão direito do mouse em "UnitTest1.cs" e escolha "Executar testes"

