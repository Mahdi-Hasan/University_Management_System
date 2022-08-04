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
     def image = docker.build "ums:1.0"
    }
  }
  }
  stage('Deploy') {
            steps {
                script{
                        docker.withRegistry('https://vivasoft.signin.aws.amazon.com/console', 'ap-southeast-2:aws-credentials') {
                    app.push("${env.BUILD_NUMBER}")
                    app.push("latest")
                    }
                }
            }
        }
 }
}
