Navigate to the project root containing .csproj file from command prompt and run following commands

'docker build -t pmd_be -f Dockerfile .'

after build is finished, run the following

'docker run -it --rm -p 32455:8080 --name pmd_be pmd_be'
