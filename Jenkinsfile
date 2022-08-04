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
     def image = docker.build "sadman39/ums:1.0"
    }
  }
  }
  stage('Deploy') {
   steps{
    script{
    sh '''docker.withRegistry('https://registry.hub.docker.com', 'git''') {
      app.push("latest")        
              }
    }
   }
   }
 }
}
