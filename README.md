# Instructions To Build BestCloud4Me Study Case

![Tests](https://github.com/kongeee/bc4m_case_study/actions/workflows/run-test.yml/badge.svg)

To implement this project, run following instructions:

```
git clone https://github.com/kongeee/bc4m_case_study.git
cd ./bc4m_case_study
docker build -t bc4m/casestudy:v1.2 .
docker run -p 5000:80 bc4m/casestudy:v1.2
```

It can be accessed on [localhost:5000](http://localhost:5000)

Application codes are here **BCFM/Controllers/BCFMController.cs**

There is a simple test here **Test/BCFMControllerTest.cs**


