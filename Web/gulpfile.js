const gulp = require('gulp');
const autoprefixer = require('gulp-autoprefixer');
const clean = require('gulp-clean');
const cleanCss = require('gulp-clean-css');
const concat = require('gulp-concat');
const minify = require('gulp-minify');
const rename = require('gulp-rename');


// Constants
const actionsApplication = 'actions-application';
const actionsClient = 'actions-client';
const cleanApplication = 'cleanApplication';
const copyAppFonts = 'copyAppFonts';
const copyAppImages = 'copyAppImages';
const baseJs = 'baseJs';
const baseCss = 'baseCss';
const cpJs = 'cpJs';
const cpCss = 'cpCss';

const cleanClient = 'cleanClient';
const copyClientFonts = 'copyClientFonts';
const copyClientImages = 'copyClientImages';
const clientJs = 'clientJs';
const clientCss = 'clientCss';
const underConstructionJs = 'underConstructionJs';
const underConstructionCss = 'underConstructionCss';
const spaJs = 'spaJs';
const spaCss = 'spaCss';


// Browser support
const AUTOPREFIXER_BROWSERS = [
    'ie >= 10',
    'ie_mob >= 10',
    'ff >= 30',
    'chrome >= 34',
    'safari >= 7',
    'opera >= 23',
    'ios >= 7',
    'android >= 4.4',
    'bb >= 10'
];


// application - cleanup dist folder
gulp.task(cleanApplication, function () {
    return gulp.src('./application/static/dist/*', { read: false })
        .pipe(clean());
});
// application - copy images
gulp.task(copyAppImages, function () {
    return gulp.src('./application/images/**/*.*')
        .pipe(gulp.dest('./application/static/dist/images'));
});
// application - copy fonts
gulp.task(copyAppFonts, function () {
    return gulp.src('./application/files/fonts/*.*')
        .pipe(gulp.dest('./application/static/dist/fonts'));
});
// application - base js
gulp.task(baseJs, function () {
    return gulp.src(['./application/static/src/base/js/jquery.min.js',
        './application/static/src/base/js/jquery-ui.min.js',
        './application/static/src/base/js/jquery-impromptu.5.2.1.js',
        './application/static/src/base/js/farschidus.js'])
        .pipe(concat('base.js'))
        .pipe(minify({
            ext: {
                min: '.js'
            },
            noSource: true
        }))
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('./application/static/dist/js'));
});
// application - base css
gulp.task(baseCss, function () {
    return gulp.src('./application/static/src/base/css/*.css')
        .pipe(autoprefixer({
            cascade: true
        }))
        .pipe(concat('base.css'))
        .pipe(cleanCss())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('./application/static/dist/css'));
});
// application - app js
gulp.task(cpJs, function () {
    return gulp.src(['./application/static/src/app/js/jstree.js'])
        .pipe(concat('cp.js'))
        .pipe(minify({
            ext: {
                min: '.js'
            },
            noSource: true
        }))
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('./application/static/dist/js'));
});
// application - app css
gulp.task(cpCss, function () {
    return gulp.src(['./application/static/src/app/css/reset.css',
        './application/static/src/app/css/menu.css',
        './application/static/src/app/css/fonts.css',
        './application/static/src/app/css/messageBox.css',
        './application/static/src/app/css/confirmPopup.css',
        './application/static/src/app/css/cp.css',
        './application/static/src/app/css/jstree.css'])
        .pipe(autoprefixer({
            cascade: true
        }))
        .pipe(concat('cp.css'))
        .pipe(cleanCss())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('./application/static/dist/css'));
});

// client - cleanup dist folder
gulp.task(cleanClient, function () {
    return gulp.src('./client/static/dist/*', { read: false })
        .pipe(clean());
});
// client - copy fonts
gulp.task(copyClientFonts, function () {
    return gulp.src('./client/files/fonts/**/*.*')
        .pipe(gulp.dest('./client/static/dist/fonts'));
});
// client - copy images
gulp.task(copyClientImages, function () {
    return gulp.src('./client/images/public/**/*.*')
        .pipe(gulp.dest('./client/static/dist/images'));
});
// client - bundle js
gulp.task(clientJs, function () {
    return gulp.src(['./client/static/src/js/jquery.easing.js',
        './client/static/src/js/bootstrap.min.js',
        './client/static/src/js/public.js'])
        .pipe(concat('client.js'))
        .pipe(minify({
            ext: {
                min: '.js'
            },
            noSource: true
        }))
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('./client/static/dist/js'));
});
// client - bundle css
gulp.task(clientCss, function () {
    return gulp.src(['./client/static/src/css/bootstrap.min.css',
        './client/static/src/css/fonts.css',
        './client/static/src/css/notification.css',
        './client/static/src/css/font-awesome.min.css',
        './client/static/src/css/login.css',
        './client/static/src/css/public.css',
        './client/static/src/css/animate.css'])
        .pipe(autoprefixer({
            cascade: true
        }))
        .pipe(concat('client.css'))
        .pipe(cleanCss())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('./client/static/dist/css'));
});
// client - under construction js
gulp.task(underConstructionJs, function () {
    return gulp.src(['./application/static/src/base/js/jquery.min.js',
        './client/static/src/js/bootstrap.min.js',
        './client/static/src/js/flipclock.min.js',
        './client/static/src/js/moment.min.js',
        './client/static/src/js/moment-timezone.min.js',
        './client/static/src/js/moment-timezone-with-data.min.js',
        './client/static/src/js/countdowntime.js',
        './client/static/src/js/underConstruction.js'])
        .pipe(concat('underConstruction.js'))
        .pipe(minify({
            ext: {
                min: '.js'
            },
            noSource: true
        }))
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('./client/static/dist/js'));
});
// client - under construction css
gulp.task(underConstructionCss, function () {
    return gulp.src(['./client/static/src/css/bootstrap.min.css',
        './client/static/src/css/font-awesome.min.css',
        './client/static/src/css/flipclock.css', 
        './client/static/src/css/underConstruction-util.css',
        './client/static/src/css/underConstruction.css'])
        .pipe(autoprefixer({
            cascade: true
        }))
        .pipe(concat('underConstruction.css'))
        .pipe(cleanCss())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('./client/static/dist/css'));
});
// client - single page js
gulp.task(spaJs, function () {
    return gulp.src(['./application/static/src/base/js/jquery.min.js',
        './client/static/src/js/bootstrap.min.js',
        './client/static/src/js/jquery.easing.js'])
        .pipe(concat('spa.js'))
        .pipe(minify({
            ext: {
                min: '.js'
            },
            noSource: true
        }))
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('./client/static/dist/js'));
});
// client - single page css
gulp.task(spaCss, function () {
    return gulp.src(['./client/static/src/css/bootstrap.min.css',
        './client/static/src/css/fonts.css',
        './client/static/src/css/public.css'])
        .pipe(autoprefixer({
            cascade: true
        }))
        .pipe(concat('spa.css'))
        .pipe(cleanCss())
        .pipe(rename({ suffix: '.min' }))
        .pipe(gulp.dest('./client/static/dist/css'));
});

// Actions
gulp.task(actionsApplication, gulp.series(cleanApplication, copyAppFonts, copyAppImages, baseJs, baseCss, cpJs, cpCss));
gulp.task(actionsClient, gulp.series(cleanClient, copyClientFonts, copyClientImages, clientJs, clientCss, underConstructionJs, underConstructionCss, spaJs, spaCss));
gulp.task('A-FastClientBuild', gulp.series(cleanClient, copyClientFonts, copyClientImages, clientJs, clientCss));

gulp.task('actions-allBuild', gulp.parallel([actionsApplication, actionsClient]));
