pipeline {
 agent any
 environment {
  dotnet = 'C:\\Program Files (x86)\\dotnet\\'
 }
 stages {
  stage('Checkout') {
   steps {
    git credentialsId: 'Sadman-Saadat', url: 'https://github.com/Mahdi-Hasan/University_Management_System.git', branch: 'devops-test'
   }
  }
  stage('Restore PACKAGES') {
   steps {
    bat "dotnet restore --configfile NuGet.Config"
   }
  }
  stage('Clean') {
   steps {
    bat 'dotnet clean'
   }
  }
  stage('Build') {
   steps {
    bat 'dotnet build --configuration Release'
   }
  }
  stage('Pack') {
   steps {
    bat 'dotnet pack --no-build --output nupkgs'
   }
  }
 }
}
