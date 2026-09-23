pipeline {
    agent any // Запуск на любом доступном агенте (ноде)

    options {
        buildDiscarder(logRotator(numToKeepStr: '10')) // Сохранять только последние 10 сборок
        timeout(time: 1, unit: 'HOURS') // Таймаут выполнения сборки — 1 час
    }

    environment {
        APP_NAME = 'my-application'
    }

    stages {
        stage('Checkout') {
            steps {
                echo 'Получение исходного кода из репозитория...'
                git url: 'https://github.com/zniska/MySolutionTMS', branch: 'main'
            }
        }

        stage('Build') {
            steps {
                echo 'Build project'
                sh 'dotnet restore'
                sh 'dotnet build'
            }
        }

        stage('Test') {
            steps {
                echo 'Start Testing'
                sh 'dotnet test'
            }
            }
    }
    post {
        always {
            allure([ results: [[path: 'allure-results']]])
          }
}
}
