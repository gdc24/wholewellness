CREATE TYPE mealType AS ENUM (
  'breakfast',
  'lunch',
  'dinner',
  'snack'
);

CREATE TYPE intensity AS ENUM (
  'low',
  'med',
  'high'
);

CREATE TYPE muscleGroup AS ENUM (
  'arms',
  'abs',
  'butt',
  'legs'
);

CREATE TYPE equipment AS ENUM (
  'none',
  'dumbbells',
  'treadmill',
  'elliptical',
  'exerciseBall',
  'foamRoller',
  'stationaryBike',
  'jumpRope'
);

CREATE TABLE "user" (
  "intUserID" SERIAL PRIMARY KEY,
  "strUsername" varchar UNIQUE NOT NULL,
  "intWeight" int NOT NULL,
  "intHeightInInches" int NOT NULL,
  "exerciseLevel" intensity NOT NULL,
  "intAllotedCalorites" int NOT NULL,
  "intAllotedExerciseMinutes" int NOT NULL
);

CREATE TABLE "day" (
  "intDayID" SERIAL PRIMARY KEY,
  "dtmDate" date NOT NULL,
  "intCalsLeft" int NOT NULL,
  "intUserID" int NOT NULL
);

CREATE TABLE "dayMeal" (
  "intDayMealID" SERIAL PRIMARY KEY,
  "intDayID" int NOT NULL,
  "intMealID" int NOT NULL
);

CREATE TABLE "dayExercise" (
  "intDayExerciseID" SERIAL PRIMARY KEY,
  "intDayID" int,
  "intWorkoutRoutineID" int NOT NULL
);

CREATE TABLE "foodItem" (
  "intFoodItemID" SERIAL PRIMARY KEY,
  "strName" varchar NOT NULL,
  "intCalories" int NOT NULL,
  "strBrandName" varchar
);

CREATE TABLE "meal" (
  "intMealID" SERIAL PRIMARY KEY,
  "mealType" mealType NOT NULL,
  "intUserID" int NOT NULL
);

CREATE TABLE "foodMeal" (
  "intFoodMealID" SERIAL PRIMARY KEY,
  "intMealID" int NOT NULL,
  "intFoodItemID" int NOT NULL
);

CREATE TABLE "favoritesFood" (
  "intFavoritesFoodID" SERIAL PRIMARY KEY,
  "intUserID" int NOT NULL,
  "intFoodItemID" int NOT NULL
);

CREATE TABLE "healthierOptions" (
  "intHealthierOptionID" SERIAL PRIMARY KEY,
  "intOriginalFoodItemID" int NOT NULL,
  "intAlternativeFoodItemID" int NOT NULL
);

CREATE TABLE "exerciseType" (
  "intExerciseTypeID" SERIAL PRIMARY KEY,
  "muscleGroup" muscleGroup NOT NULL,
  "equipment" equipment NOT NULL,
  "intCaloriesBurned" int NOT NULL,
  "ysnAccessibility" boolean NOT NULL,
  "intTime" int NOT NULL,
  "intensity" intensity NOT NULL
);

CREATE TABLE "favortiesExercise" (
  "intExerciseFavortiesID" SERIAL PRIMARY KEY,
  "intUserID" int NOT NULL,
  "intExerciseTypeID" int NOT NULL
);

CREATE TABLE "muscleExercise" (
  "intMuscleExerciseID" SERIAL PRIMARY KEY,
  "muscleGroup" muscleGroup NOT NULL,
  "intExerciseTypeID" int NOT NULL
);

CREATE TABLE "workoutRoutine" (
  "intWorkoutRoutineID" SERIAL PRIMARY KEY,
  "intTotalMinutes" int NOT NULL,
  "intTotalCalsBurned" int NOT NULL,
  "intUserID" int NOT NULL
);

CREATE TABLE "workoutExerciseType" (
  "intWorkoutExerciseType" SERIAL PRIMARY KEY,
  "intExerciseTypeID" int NOT NULL,
  "intWorkoutRoutineID" int NOT NULL
);

ALTER TABLE "day" ADD FOREIGN KEY ("intUserID") REFERENCES "user" ("intUserID");

ALTER TABLE "dayMeal" ADD FOREIGN KEY ("intDayID") REFERENCES "day" ("intDayID");

ALTER TABLE "dayMeal" ADD FOREIGN KEY ("intMealID") REFERENCES "meal" ("intMealID");

ALTER TABLE "dayExercise" ADD FOREIGN KEY ("intDayID") REFERENCES "day" ("intDayID");

ALTER TABLE "dayExercise" ADD FOREIGN KEY ("intWorkoutRoutineID") REFERENCES "workoutRoutine" ("intWorkoutRoutineID");

ALTER TABLE "meal" ADD FOREIGN KEY ("intUserID") REFERENCES "user" ("intUserID");

ALTER TABLE "foodMeal" ADD FOREIGN KEY ("intMealID") REFERENCES "meal" ("intMealID");

ALTER TABLE "foodMeal" ADD FOREIGN KEY ("intFoodItemID") REFERENCES "foodItem" ("intFoodItemID");

ALTER TABLE "favoritesFood" ADD FOREIGN KEY ("intUserID") REFERENCES "user" ("intUserID");

ALTER TABLE "favoritesFood" ADD FOREIGN KEY ("intFoodItemID") REFERENCES "foodItem" ("intFoodItemID");

ALTER TABLE "healthierOptions" ADD FOREIGN KEY ("intOriginalFoodItemID") REFERENCES "foodItem" ("intFoodItemID");

ALTER TABLE "healthierOptions" ADD FOREIGN KEY ("intAlternativeFoodItemID") REFERENCES "foodItem" ("intFoodItemID");

ALTER TABLE "favortiesExercise" ADD FOREIGN KEY ("intUserID") REFERENCES "user" ("intUserID");

ALTER TABLE "favortiesExercise" ADD FOREIGN KEY ("intExerciseTypeID") REFERENCES "exerciseType" ("intExerciseTypeID");

ALTER TABLE "muscleExercise" ADD FOREIGN KEY ("intExerciseTypeID") REFERENCES "exerciseType" ("intExerciseTypeID");

ALTER TABLE "workoutRoutine" ADD FOREIGN KEY ("intUserID") REFERENCES "user" ("intUserID");

ALTER TABLE "workoutExerciseType" ADD FOREIGN KEY ("intExerciseTypeID") REFERENCES "exerciseType" ("intExerciseTypeID");

ALTER TABLE "workoutExerciseType" ADD FOREIGN KEY ("intWorkoutRoutineID") REFERENCES "workoutRoutine" ("intWorkoutRoutineID");
