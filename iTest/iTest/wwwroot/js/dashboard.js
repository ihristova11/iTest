$(function () {
    $('.tests').DataTable();
    $('.results').DataTable();

    $('.publish-btn').on('click',
        function (e) {
            e.preventDefault();

            var url = this.parentNode.action;
            var data = $(this).id;

            var token = $(this).siblings('input[name=__RequestVerificationToken]').val();
            var headers = {};
            headers['__RequestVerificationToken'] = token;

            $.ajax({
                url: url,
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(data),
                headers: headers,
                success: (response) => {
                    console.log(response);
                    window.location.href = response;
                },
                error: (err) => {
                    console.log(err);
                }
            });
        });

    $('.disable-btn').on('click',
        function (e) {
            e.preventDefault();

            var url = this.parentNode.action;
            var data = $(this).id;

            var token = $(this).siblings('input[name=__RequestVerificationToken]').val();
            var headers = {};
            headers['__RequestVerificationToken'] = token;

            $.ajax({
                url: url,
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(data),
                headers: headers,
                success: (response) => {
                    console.log(response);
                    window.location.href = response;
                },
                error: (err) => {
                    console.log(err);
                }
            });
        });

    $('.delete-btn').on('click',
        function (e) {
            e.preventDefault();

            var url = this.parentNode.action;
            var data = $(this).id;

            var token = $(this).siblings('input[name=__RequestVerificationToken]').val();
            var headers = {};
            headers['__RequestVerificationToken'] = token;

            $.ajax({
                url: url,
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify(data),
                headers: headers,
                success: (response) => {
                    console.log(response);
                    window.location.href = response;
                },
                error: (err) => {
                    console.log(err);
                }
            });
        });
});