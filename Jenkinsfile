pipeline {
 agent any
 environment {
  dotnet = 'C:\\Program Files (x86)\\dotnet\\'
 }
 stages {
  stage('Checkout') {
   steps {
    git url: 'https://github.com/Mahdi-Hasan/University_Management_System.git', branch: 'devops-test'
   }
  }
  stage('Restore PACKAGES') {
   steps {
    sh "dotnet restore --configfile NuGet.Config"
   }
  }
  stage('Clean') {
   steps {
    sh 'dotnet clean'
   }
  }
  stage('Build') {
   steps {
    sh 'dotnet build --configuration Release'
   }
  }
  stage('Pack') {
   steps {
    sh 'dotnet pack --no-build --output nupkgs'
   }
  }
 }
}
