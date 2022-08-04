pipeline {
 agent any
 
 stages {
  stage('Checkout') {
   steps {
    git url: 'https://github.com/Mahdi-Hasan/University_Management_System.git', branch: 'devops-test'
   }
  }
  stage('Build') {
   steps {
    script{
     dockerImage = docker.build "ums:1.0"
    }
  }
  }
 }
}
