$(function () {

    function CourseList() {
        $.ajax({
            type: 'GET',
            url: '/Student/CourseList',
            success: function (data) {
                var jsonCourse = JSON.parse(data);

                var courseInner = '<tr>';
                courseInner += '<td>수 강 과 목</td>';
                courseInner += '<td><select id=courseSelect>';

                for (var i = 0; i < jsonCourse.length; i++) {
                    courseInner += '<option value=' + jsonCourse[i].CourseModelsID + '>';
                    courseInner += jsonCourse[i].Title;
                    courseInner += '</optrion>';
                }
                courseInner += '</select></td></tr>';
                $('#schoolAdd').append(courseInner);
            },
            error: function (xhr, status, error) {
                console.log('error :' + error);
            }
        });
    }

    CourseList();

    $('#addSchoolOk').click(function () {
        var lastName = $.trim($('#lastName').val());
        var firstMidName = $.trim($('#firstMidName').val());
        var courseSelect = $('#courseSelect option:selected').val();
        if (lastName == '' || firstMidName == '') {
            return;
        }
        $.ajax({
            type: 'POST',
            url: '/Student/AddSchoolData',
            data: {
                LastName: lastName, FirstMidName: firstMidName, courseModelsID :courseSelect
            },

            success: function (data) {
                location.replace('/Student/Index');
            },
            error: function (xhr, status, error) {
                console.log('error :' + error);
            }
        });

    });
});