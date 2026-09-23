pipeline {
    agent any // Запуск на любом доступном агенте (ноде)

    options {
        buildDiscarder(logRotator(numToKeepStr: '10')) // Сохранять только последние 10 сборок
        timeout(time: 1, unit: 'HOURS') // Таймаут выполнения сборки — 1 час
    }
    
    parameters {
            choice(
                name: 'BROWSER',
                choices: ['Chrome', 'Firefox', 'Remote'],
                description: 'Browser for tests'
            )
        }

    environment {
        APP_NAME = 'my-application'
    }

    stages {
        stage('Checkout') {
            steps {
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

        stage('Tests') {
        parallel {
            stage('Smoke') {
                steps {
                withEnv(["BROWSER=${params.BROWSER}"]) {
                    sh 'dotnet test --filter "Category=smoke"'
                    }
                    }
                    }
             stage('Regression') {
                steps {
                withEnv(["BROWSER=${params.BROWSER}"]) {
                    sh 'dotnet test --filter "TestCategory=regression"'
                    }
                    }
                    }
                    }
       }
       }
    post {
        always {
            allure([ results: [[path: 'allure-results']]])
          }
          }
}
