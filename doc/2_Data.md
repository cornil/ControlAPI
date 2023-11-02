# Add some data on the project

For this project, I choose some open data available here :

https://www.data.gouv.fr/fr/datasets/fichier-consolide-des-bornes-de-recharge-pour-vehicules-electriques

Feel free to add your own data

## Tasks
 - [ ] Add Database
 - [ ] Load dataset into database
 - [ ] Connect private API to your database

## Bonus
 - [ ] Backup and restore you database
 - [ ] Track your database changes in repository


## Advices

I will use postgres in container to store my data because it is lightweight and powerfull.

The inconvenient is if a restart my container, data are lost. So I have to set up volume to keep it between restart, and have some backup to prevent error.

I like to keep database changes in my repository with entity framework migration which give me an easy way to upgrade database or rollback for each environment (development, staging, production)

For one time script, or dataset manipulation, I like to create python notebook, with libraries like pandas

## References

List of french dataset : https://www.data.gouv.fr/fr/datasets/

Postgres : https://www.postgresql.org/

Postgres docker image : https://hub.docker.com/_/postgres

Migration : https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli

Notebook in VSCode : https://code.visualstudio.com/docs/datascience/jupyter-notebooks

Pandas : https://pandas.pydata.org/