CREATE TABLE "Person" (
   person_id SERIAL,
   "name" VARCHAR(255),
   CONSTRAINT "personPK" PRIMARY KEY ("person_id")
);

INSERT INTO "Person"
("name") 
VALUES ('Dilay Özak');

INSERT INTO "Person"
("name") 
VALUES ('Agah Gök');

INSERT INTO "Person"
("name") 
VALUES ('Dilara Şamiloğlu');

INSERT INTO "Person"
("name") 
VALUES ('Esra Fettahoğlu');

INSERT INTO "Person"
("name") 
VALUES ('Eren Yıldız');

INSERT INTO "Person"
("name") 
VALUES ('Rabia Sürmeli');

INSERT INTO "Person"
("name") 
VALUES ('Osman Salih');

INSERT INTO "Person"
("name") 
VALUES ('Elif Şimşek');

CREATE TABLE "University" (
   "university_id" SERIAL,
   "university_name" VARCHAR(255),
   CONSTRAINT "UniversityPK" PRIMARY KEY ("university_id")
);

INSERT INTO "University"
("university_name") 
VALUES ('Maltepe University');

INSERT INTO "University"
("university_name") 
VALUES ('Koç University');

INSERT INTO "University"
("university_name") 
VALUES ('Bilkent University');

INSERT INTO "University"
("university_name") 
VALUES ('Sakarya University');

CREATE TABLE "Institute" (
   "institute_id" SERIAL,
   "university_id" INT,
   "institute_name"VARCHAR(255),
   CONSTRAINT "InstitutePK" PRIMARY KEY ("institute_id"),
   CONSTRAINT "InstituteFK" FOREIGN KEY ("university_id") REFERENCES "University"
   ("university_id")
);

INSERT INTO "Institute"
("university_id", "institute_name") 
VALUES ('1', 'Institute of Social Sciences');

INSERT INTO "Institute"
("university_id", "institute_name") 
VALUES ('1', 'Institute of Education');

INSERT INTO "Institute"
("university_id", "institute_name") 
VALUES ('1', 'Institute of Architecture');

INSERT INTO "Institute"
("university_id", "institute_name") 
VALUES ('1', 'Institute of Engineering');

INSERT INTO "Institute"
("university_id", "institute_name") 
VALUES ('1', 'Institute of Medicine');

INSERT INTO "Institute"
("university_id", "institute_name") 
VALUES ('2', 'Institute of Social Sciences');

INSERT INTO "Institute"
("university_id", "institute_name") 
VALUES ('2', 'Institute of Education');

INSERT INTO "Institute"
("university_id", "institute_name") 
VALUES ('2', 'Institute of Architecture');

INSERT INTO "Institute"
("university_id", "institute_name") 
VALUES ('2', 'Institute of Engineering');

INSERT INTO "Institute"
("university_id", "institute_name") 
VALUES ('2', 'Institute of Medicine');

INSERT INTO "Institute"
("university_id", "institute_name") 
VALUES ('3', 'Institute of Social Sciences');

INSERT INTO "Institute"
("university_id", "institute_name") 
VALUES ('3', 'Institute of Education');

INSERT INTO "Institute"
("university_id", "institute_name") 
VALUES ('3', 'Institute of Architecture');

INSERT INTO "Institute"
("university_id", "institute_name") 
VALUES ('3', 'Institute of Engineering');

INSERT INTO "Institute"
("university_id", "institute_name") 
VALUES ('3', 'Institute of Medicine');

INSERT INTO "Institute"
("university_id", "institute_name") 
VALUES ('4', 'Institute of Social Sciences');

INSERT INTO "Institute"
("university_id", "institute_name") 
VALUES ('4', 'Institute of Education');

INSERT INTO "Institute"
("university_id", "institute_name") 
VALUES ('4', 'Institute of Architecture');

INSERT INTO "Institute"
("university_id", "institute_name") 
VALUES ('4', 'Institute of Engineering');

INSERT INTO "Institute"
("university_id", "institute_name") 
VALUES ('4', 'Institute of Medicine');


CREATE TABLE "Thesis" (
   "thesis_no" INT,
   "title" VARCHAR(500),
   "abstract" TEXT,
   "author" INT,
   "year" INT,
   "type" VARCHAR(50),
   "university" INT,
   "institute" INT,    
   "num_pages" INT,
   "language" VARCHAR(50),
   "submission_date" DATE,
   CONSTRAINT "thesisPK" PRIMARY KEY ("thesis_no"),
   CONSTRAINT "ThesisFK" FOREIGN KEY ("university") REFERENCES "University"
   ("university_id"),
    CONSTRAINT "ThesisFK2" FOREIGN KEY ("institute") REFERENCES "Institute"
   ("institute_id"),
   CONSTRAINT "ThesisFK3" FOREIGN KEY ("author") REFERENCES "Person"
   ("person_id")
);

INSERT INTO "Thesis"
("thesis_no", "title", "abstract", "author", "year", "type", "university", "institute", "num_pages", "language", "submission_date")
VALUES (1, 'Applications of Artificial Intelligence', 
        'This thesis explores various applications of artificial intelligence technologies, with a focus on how deep learning 
        algorithms can be utilized in areas such as image recognition, natural language processing, and recommendation systems. 
        The developed sample applications and performance analyses demonstrate the applicability of AI-based systems to real-world 
        problems.', 
        1, 2023, 'Master', 1, 4, 80, 'English', '2023-01-15');

INSERT INTO "Thesis"
("thesis_no", "title", "abstract", "author", "year", "type", "university", "institute", "num_pages", "language", "submission_date")
VALUES (2, 'Innovative Teaching Methods in STEM Education', 
        'This thesis explores innovative teaching methods in STEM (Science, Technology, Engineering, and Mathematics) 
        education. It investigates the effectiveness of project-based learning, technology integration, and interactive 
        approaches in enhancing student engagement and learning outcomes.', 
        2, 2022, 'PhD', 2, 2, 120, 'English', '2022-12-01');

INSERT INTO "Thesis"
("thesis_no", "title", "abstract", "author", "year", "type", "university", "institute", "num_pages", "language", "submission_date")
VALUES (3, 'Sustainable Architecture and Urban Planning', 
        'This thesis investigates sustainable architecture principles and their impact on urban planning. It analyzes 
        environmentally friendly building materials, energy-efficient designs, and their contribution to creating 
        sustainable and livable urban environments.', 
        3, 2023, 'Doctorate', 3, 3, 100, 'English', '2023-03-20');

INSERT INTO "Thesis"
("thesis_no", "title", "abstract", "author", "year", "type", "university", "institute", "num_pages", "language", "submission_date")
VALUES (4, 'Sosyal Medyanın Toplum Üzerindeki Etkisi',
        'Bu tez, sosyal medyanın toplumsal davranışlar ve iletişim kalıpları üzerindeki etkisini incelemektedir. Çağdaş toplumda
        sosyal medya platformlarının, halkın görüşlerini şekillendirme, ilişkileri etkileme ve bilgi yayılmasındaki rolünü
        analiz etmektedir.', 
        4, 2022, 'Master', 1, 1, 90, 'Turkish', '2022-11-10');

INSERT INTO "Thesis"
("thesis_no", "title", "abstract", "author", "year", "type", "university", "institute", "num_pages", "language", "submission_date")
VALUES (5, 'Tıbbi Araştırmalarda Etik Düşünce', 
        'Bu tez, tıbbi araştırmalarda etik düşünceyi ele almakta ve özellikle insan deneklerin korunması ve bilimsel çalışmalardaki 
        bütünlüğün sürdürülmesine odaklanmaktadır. Araştırmacılara sorumlu ve etik tıbbi araştırmalar yapmalarında rehberlik etmek 
        amacıyla vaka çalışmalarını ve etik çerçeveleri değerlendirmektedir.', 
        1, 2023, 'Master', 4, 4, 110, 'Turkish', '2023-02-28');


CREATE TABLE "Supervisor" (
   "supervisor_id" SERIAL,
   "person_id" INT,
   "thesis_no" INT,
   CONSTRAINT "SupervisorPK" PRIMARY KEY ("supervisor_id"),
   CONSTRAINT "SupervisorFK" FOREIGN KEY ("person_id") REFERENCES "Person"
   ("person_id"),
   CONSTRAINT "SupervisorFK2" FOREIGN KEY ("thesis_no") REFERENCES "Thesis"
   ("thesis_no")
);

INSERT INTO "Supervisor"
("person_id", "thesis_no") 
VALUES ('5', '1');

INSERT INTO "Supervisor"
("person_id", "thesis_no") 
VALUES ('6', '2');

INSERT INTO "Supervisor"
("person_id", "thesis_no") 
VALUES ('7', '3');

INSERT INTO "Supervisor"
("person_id", "thesis_no") 
VALUES ('8', '4');

INSERT INTO "Supervisor"
("person_id", "thesis_no") 
VALUES ('9', '5');

CREATE TABLE "Cosupervisor" (
   "cosupervisor_id" SERIAL,
   "person_id" INT,
   "thesis_no" INT,
   "university" INT,
   CONSTRAINT "CosupervisorPK" PRIMARY KEY ("cosupervisor_id"),
   CONSTRAINT "CosupervisorFK" FOREIGN KEY ("person_id") REFERENCES "Person"
   ("person_id"),
   CONSTRAINT "CosupervisorFK2" FOREIGN KEY ("thesis_no") REFERENCES "Thesis"
   ("thesis_no")
);

INSERT INTO "Cosupervisor"
("person_id", "thesis_no", "university") 
VALUES ('9', '2', '4');

INSERT INTO "Cosupervisor"
("person_id", "thesis_no", "university") 
VALUES ('6', '5', '1');

CREATE TABLE "SubjectTopic" (
   "subject_topic_id" SERIAL,
   "subject_topic_name" VARCHAR(255),
   CONSTRAINT "SubjectTopicPK" PRIMARY KEY ("subject_topic_id")
);

INSERT INTO "SubjectTopic"
("subject_topic_name") 
VALUES ('Medicine');

INSERT INTO "SubjectTopic"
("subject_topic_name") 
VALUES ('Education');


INSERT INTO "SubjectTopic"
("subject_topic_name") 
VALUES ('Social Sciences');

INSERT INTO "SubjectTopic"
("subject_topic_name") 
VALUES ('Architecture');


INSERT INTO "SubjectTopic"
("subject_topic_name") 
VALUES ('Engineering');

CREATE TABLE "ThesisSubjectTopic" (
   "thesis_no" INT,
   "subject_topic_id" INT,
   CONSTRAINT "ThesisSubjectTopicPK" PRIMARY KEY ("subject_topic_id", "thesis_no"),
   CONSTRAINT "ThesisSubjectTopicFK" FOREIGN KEY ("thesis_no") REFERENCES "Thesis"
   ("thesis_no"),
   CONSTRAINT "ThesisSubjectTopicFK2" FOREIGN KEY ("subject_topic_id") REFERENCES "SubjectTopic"
   ("subject_topic_id")
   
);

INSERT INTO "ThesisSubjectTopic"
("thesis_no", "subject_topic_id") 
VALUES ('5', '1');

INSERT INTO "ThesisSubjectTopic"
("thesis_no", "subject_topic_id") 
VALUES ('2', '2');

INSERT INTO "ThesisSubjectTopic"
("thesis_no", "subject_topic_id") 
VALUES ('4', '3');

INSERT INTO "ThesisSubjectTopic"
("thesis_no", "subject_topic_id") 
VALUES ('3', '4');

INSERT INTO "ThesisSubjectTopic"
("thesis_no", "subject_topic_id") 
VALUES ('1', '5');

CREATE TABLE "Keyword" (
   "keyword_id" SERIAL,
   "keyword_text" VARCHAR(255),
   CONSTRAINT "KeywordPK" PRIMARY KEY ("keyword_id")
);

INSERT INTO "Keyword" 
("keyword_text") 
VALUES ('Artificial Intelligence');

INSERT INTO "Keyword" 
("keyword_text") 
VALUES ('STEM Education');

INSERT INTO "Keyword" 
("keyword_text") 
VALUES ('Sustainable Architecture');

INSERT INTO "Keyword" 
("keyword_text") 
VALUES ('Social Media Impact');

INSERT INTO "Keyword" 
("keyword_text") 
VALUES ('Medical Ethics');

CREATE TABLE "ThesisKeyword" (
   "thesis_no" INT,
   "keyword_id" INT,
   CONSTRAINT "ThesisKeywordPK" PRIMARY KEY ("keyword_id", "thesis_no"),
   CONSTRAINT "ThesisKeywordFK" FOREIGN KEY ("thesis_no") REFERENCES "Thesis"
   ("thesis_no"),
   CONSTRAINT "ThesisKeywordFK2" FOREIGN KEY ("keyword_id") REFERENCES "Keyword"
   ("keyword_id")
    
);

INSERT INTO "ThesisKeyword" 
("thesis_no", "keyword_id") 
VALUES ('1', '1');

INSERT INTO "ThesisKeyword" 
("thesis_no", "keyword_id") 
VALUES ('2', '2');

INSERT INTO "ThesisKeyword" 
("thesis_no", "keyword_id") 
VALUES ('3', '3');

INSERT INTO "ThesisKeyword" 
("thesis_no", "keyword_id") 
VALUES ('4', '4');

INSERT INTO "ThesisKeyword" 
("thesis_no", "keyword_id") 
VALUES ('5', '5');