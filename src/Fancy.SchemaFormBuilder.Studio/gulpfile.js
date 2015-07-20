var gulp = require('gulp');
var del = require('del');
var uglify = require('gulp-uglify');
var concat = require('gulp-concat');
var sourcemaps = require('gulp-sourcemaps');
var bower = require('gulp-bower');

gulp.task('bower', function () {
    bower({ layout: 'byComponent' });
});

gulp.task('lib-clean', function () {
    return del('wwwroot/lib/*');
});

gulp.task('lib-ace', function () {
    return gulp.src([
        'bower_components/ace-builds/src-min-noconflict/ace.js',
        'bower_components/ace-builds/src-min-noconflict/theme-monokai.js',
        'bower_components/ace-builds/src-min-noconflict/mode-csharp.js'
    ])
      .pipe(gulp.dest('wwwroot/lib/js'));
});

gulp.task('lib-js', function () {
    return gulp.src([
        'bower_components/jquery/dist/jquery.min.js',
        'bower_components/bootstrap/dist/js/bootstrap.min.js',
        'bower_components/angular/angular.min.js',
        'bower_components/angular-ui-router/release/angular-ui-router.min.js',
        'bower_components/angular-sanitize/angular-sanitize.min.js',
        'bower_components/tv4/tv4.js',
        'bower_components/objectpath/lib/ObjectPath.js',
        'bower_components/angular-schema-form/dist/schema-form.min.js',
        'bower_components/angular-schema-form/dist/bootstrap-decorator.min.js',
        'bower_components/angular-ui-ace/ui-ace.min.js'
    ])
      .pipe(concat('libs.min.js'))
      .pipe(gulp.dest('wwwroot/lib/js'));
});

gulp.task('lib-css', function () {
    return gulp.src('bower_components/bootstrap/dist/css/*.min.css')
      .pipe(gulp.dest('wwwroot/lib/css'));
});

gulp.task('lib-fonts', function () {
    return gulp.src('bower_components/bootstrap/dist/fonts/*.{eot,svg,ttf,woff,woff2}')
      .pipe(gulp.dest('wwwroot/lib/fonts'))
});

gulp.task('lib', ['bower', 'lib-ace', 'lib-js', 'lib-css', 'lib-fonts'], function () {
});

gulp.task('script', function () {
    return gulp
      .src('wwwroot/app/**/*.js')
      .pipe(sourcemaps.init())
      .pipe(concat('app.min.js'))
      //.pipe(uglify())
      .pipe(sourcemaps.write('./'))
      .pipe(gulp.dest('wwwroot'));
});

gulp.task('watch', function () {
    gulp.watch('wwwroot/app/**/*.js', ['script']);
});