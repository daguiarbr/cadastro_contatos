cadastro_contatos
=================

Cadastro de contatos simples, usando APS.NET MVC, C#, SQL Server

Executar os scripts de criação do banco de dados na seguinte ordem:

1º) script1.sql
2º) script2.sql
3º) script3.sql

Obs. Script d rollback opcional:

1º) rollback_script.sql


Para o funcionamento do sistema é necessário alterar a string de conexão com o banco de dados.
Para isto altere as linhas 15 e 16 do arquivo Contacts\Contacts\Web.config conforme o exemplo abaixo:

Ex.
  <connectionStrings>
      <add name="ApplicationServices" connectionString="Data Source=DOUGLAS-PC;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|aspnetdb.mdf;User Instance=true" providerName="System.Data.SqlClient" />    
      <add name="DefaultConStr" connectionString="Data Source=DOUGLAS-PC;Initial Catalog=douglas_db;Persist Security Info=True;Connect Timeout=180;User ID=sa;Password=753535;Connection Reset=True;Connection Lifetime=220;" providerName="System.Data.SqlClient"/>
  </connectionStrings>
  
  
Para o funcionamento dos testes é necessário alterar a string de conexão com o banco de dados.
Para isto altere as linhas 8 e 9 do arquivo Contacts\Contacts.Tests\App.config conforme o exemplo abaixo:

Ex.
  <connectionStrings>
    <add name="ApplicationServices" connectionString="Data Source=DOUGLAS-PC;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|aspnetdb.mdf;User Instance=true" providerName="System.Data.SqlClient" />
    <add name="DefaultConStr" connectionString="Data Source=DOUGLAS-PC;Initial Catalog=douglas_db;Persist Security Info=True;Connect Timeout=180;User ID=sa;Password=753535;Connection Reset=True;Connection Lifetime=220;" providerName="System.Data.SqlClient"/>
  </connectionStrings>
  
