## Báo Cáo Assignment: User Management
Giới Thiệu: Bài Assignment "User Management" tập trung vào việc phát triển một hệ thống quản lý người dùng cơ bản. Hệ thống này cung cấp các chức năng đăng ký người dùng, đăng nhập, thay đổi mật khẩu và quản lý thông tin người dùng thông qua giao diện tương tác với Web Server qua Postman.
2.Các chức năng đã làm được: 
## I.Mô Tả Trang "Đăng Ký" (User Registration)
![image](https://github.com/user-attachments/assets/119a8ffa-c527-4f81-80d8-7205f7ea2a39)

1. Mục Đích:

Trang "Đăng Ký" được thiết kế để cho phép người dùng mới tự tạo tài khoản trong hệ thống. Đây là bước đầu tiên để người dùng có thể truy cập và sử dụng các chức năng của hệ thống sau khi đã được xác thực.

2. Các Thành Phần Chính:

Form Đăng Ký:

Fullname (Họ và Tên): Trường bắt buộc, nơi người dùng nhập tên đầy đủ của mình.
Username (Tên Đăng Nhập): Trường bắt buộc, định danh duy nhất mà người dùng sẽ sử dụng để đăng nhập vào hệ thống.
Email: Trường bắt buộc, dùng để liên lạc và có thể được sử dụng để khôi phục mật khẩu khi cần thiết.
Password (Mật Khẩu): Trường bắt buộc, người dùng sẽ nhập mật khẩu dùng để bảo vệ tài khoản của mình. Mật khẩu sẽ được mã hóa trước khi lưu vào cơ sở dữ liệu để đảm bảo tính bảo mật.
Confirm Password (Xác Nhận Mật Khẩu): Trường bắt buộc, dùng để xác nhận mật khẩu đã nhập nhằm tránh sai sót.
Gender (Giới Tính): Tùy chọn, giúp xác định giới tính của người dùng.
Date Of Birth (Ngày Sinh): Tùy chọn, cho phép người dùng nhập ngày sinh của họ.
Address (Địa Chỉ): Tùy chọn, địa chỉ nơi ở của người dùng.
Phone (Số Điện Thoại): Tùy chọn, số điện thoại liên lạc của người dùng.
Profile Image (Ảnh Đại Diện): Tùy chọn, người dùng có thể tải lên một hình ảnh để làm ảnh đại diện.
Nút Hành Động:

Register (Đăng Ký): Nút để xác nhận việc tạo tài khoản mới với các thông tin đã nhập.
Cancel (Hủy): Nút để hủy bỏ quá trình đăng ký và quay lại trang trước hoặc trang chính.
3. Quy Trình Hoạt Động:

Nhập Thông Tin: Người dùng mới sẽ điền đầy đủ thông tin cá nhân và tài khoản vào form đăng ký.

Kiểm Tra Tính Hợp Lệ: Hệ thống sẽ kiểm tra xem thông tin nhập vào có hợp lệ không, bao gồm kiểm tra xem Email hoặc Username đã tồn tại trong hệ thống chưa, và kiểm tra xem mật khẩu có đáp ứng các tiêu chuẩn bảo mật hay không.

Mã Hóa Mật Khẩu: Sau khi người dùng nhập mật khẩu, hệ thống sẽ thực hiện mã hóa mật khẩu trước khi lưu vào cơ sở dữ liệu. Điều này nhằm bảo vệ thông tin cá nhân của người dùng khỏi các truy cập trái phép.

Lưu Dữ Liệu: Nếu thông tin hợp lệ, hệ thống sẽ lưu dữ liệu của người dùng mới vào cơ sở dữ liệu, tạo tài khoản mới cho họ.

Xác Nhận Đăng Ký Thành Công: Sau khi đăng ký thành công, người dùng có thể được chuyển hướng đến trang đăng nhập hoặc nhận thông báo về việc đăng ký thành công.

4. Phân Quyền:

Tất Cả Người Dùng: Trang này có thể truy cập công khai và bất kỳ ai muốn tạo tài khoản trong hệ thống đều có thể sử dụng trang "Đăng Ký".
b)Login:
![image](https://github.com/user-attachments/assets/0a9c7d56-9493-4bbf-8ec7-d316f61f7b0a)

 Người dùng đã đăng ký có thể đăng nhập vào hệ thống bằng cách cung cấp tên đăng nhập và mật khẩu. 
Mật khẩu người dùng được bảo mật bằng cách mã hóa trước khi lưu trữ.
II.  Trang "Account Detail
![image](https://github.com/user-attachments/assets/6a120b04-f159-48b6-a646-27f4f39870c9)
1. Giới Thiệu:
Trang "Account Details" cung cấp cho người dùng khả năng xem chi tiết thông tin cá nhân của họ sau khi đã đăng nhập vào hệ thống. Trang này là một phần quan trọng trong hệ thống quản lý tài khoản, cho phép người dùng kiểm tra và xác nhận các thông tin liên quan đến tài khoản của mình.

2. Mục Đích:
Mục đích của trang "Account Details" là cung cấp cho người dùng cái nhìn toàn diện về thông tin cá nhân đã được lưu trữ trong hệ thống, bao gồm:

Thông tin cá nhân như tên đầy đủ, email, giới tính, ngày sinh, địa chỉ, số điện thoại.
Thông tin đăng nhập như tên người dùng (username) và vai trò (role) trong hệ thống.
Hình ảnh đại diện (nếu có).
3. Chức Năng:
Hiển Thị Thông Tin Cá Nhân: Người dùng có thể xem chi tiết tất cả thông tin cá nhân mà họ đã cung cấp trong quá trình đăng ký hoặc chỉnh sửa tài khoản.
Hình Ảnh Đại Diện: Nếu người dùng đã tải lên hình ảnh đại diện, hình ảnh này sẽ được hiển thị trên trang chi tiết.
Thông Tin Tài Khoản: Tên đăng nhập và vai trò của người dùng trong hệ thống cũng được hiển thị để người dùng có thể kiểm tra quyền hạn của mình.
4. Cách Thức Hoạt Động:
Khi người dùng truy cập vào trang "Account Details," hệ thống sẽ kiểm tra thông tin đăng nhập để đảm bảo rằng người dùng đã xác thực danh tính của mình.
Trang sẽ truy xuất thông tin cá nhân từ cơ sở dữ liệu dựa trên ID người dùng đã đăng nhập và hiển thị thông tin này trên giao diện người dùng.
Nếu người dùng chưa đăng nhập, hệ thống sẽ tự động chuyển hướng người dùng đến trang đăng nhập.

## III. Trang Edit Account (Chỉnh Sửa Tài Khoản)
![image](https://github.com/user-attachments/assets/aa65a539-1a30-44a6-a339-824dd5ea8e7b)

1. Giới Thiệu:
Trang "Edit Account" cho phép người dùng cập nhật và chỉnh sửa thông tin cá nhân đã lưu trong hệ thống. Đây là một tính năng quan trọng trong hệ thống quản lý người dùng, giúp người dùng dễ dàng duy trì tính chính xác và cập nhật của thông tin cá nhân.

2. Mục Đích:
Mục đích của trang "Edit Account" là cung cấp một giao diện cho phép người dùng:

Cập nhật thông tin cá nhân như họ tên, email, giới tính, ngày sinh, địa chỉ, và số điện thoại.
Thay đổi tên đăng nhập (username) và mật khẩu.
Cập nhật hình ảnh đại diện (nếu có).
3. Chức Năng:
Chỉnh Sửa Thông Tin Cá Nhân: Người dùng có thể thay đổi các thông tin như họ tên, email, số điện thoại, địa chỉ, và giới tính.
Cập Nhật Tên Đăng Nhập và Mật Khẩu: Người dùng có thể thay đổi tên đăng nhập và mật khẩu của mình. Khi mật khẩu mới được nhập, hệ thống sẽ yêu cầu xác nhận lại mật khẩu để đảm bảo tính chính xác.
Tải Lên Hình Ảnh Đại Diện: Người dùng có thể thay đổi hình ảnh đại diện của mình bằng cách tải lên một tệp hình ảnh mới.
Lưu Thay Đổi: Sau khi chỉnh sửa, người dùng có thể lưu các thay đổi để cập nhật thông tin trong cơ sở dữ liệu.
4. Cách Thức Hoạt Động:
Hiển Thị Thông Tin Hiện Tại: Khi người dùng truy cập vào trang "Edit Account," hệ thống sẽ tự động tải và hiển thị các thông tin hiện tại của người dùng từ cơ sở dữ liệu.
Chỉnh Sửa Thông Tin: Người dùng có thể thực hiện thay đổi thông qua các trường nhập liệu (input fields) trên giao diện.
Lưu Thay Đổi: Sau khi hoàn tất việc chỉnh sửa, người dùng nhấn nút "Lưu" (Save) để lưu các thay đổi. Hệ thống sẽ kiểm tra tính hợp lệ của dữ liệu và cập nhật thông tin trong cơ sở dữ liệu.
Thông Báo Lỗi: Nếu có lỗi xảy ra trong quá trình cập nhật (ví dụ: email hoặc username đã tồn tại), hệ thống sẽ hiển thị thông báo lỗi để người dùng điều chỉnh.

## IV. Trang Users List (Danh Sách Người Dùng)
![image](https://github.com/user-attachments/assets/525a12b3-5e79-492c-bcfc-1fbd93836ece)

1. Giới Thiệu:
Trang "Users List" là nơi quản trị viên có thể quản lý danh sách tất cả người dùng đã đăng ký trong hệ thống. Trang này cung cấp cái nhìn tổng quan về thông tin người dùng, cho phép thực hiện các thao tác quản trị như chỉnh sửa hoặc xóa tài khoản người dùng.
2. Mục Đích:
Mục đích của trang "Users List" là cung cấp một giao diện để:
Hiển thị danh sách tất cả người dùng trong hệ thống.
Cung cấp các chức năng quản lý như chỉnh sửa, xóa người dùng.
Dễ dàng tìm kiếm và lọc người dùng theo các tiêu chí nhất định.
3. Chức Năng:
Hiển Thị Danh Sách Người Dùng:
Danh sách bao gồm các thông tin cơ bản như: Họ tên, tên đăng nhập (username), email, vai trò (role), và trạng thái (active/inactive).
Chỉnh Sửa Thông Tin Người Dùng:
Mỗi người dùng trong danh sách sẽ có một nút "Edit" (Chỉnh sửa) cho phép quản trị viên chỉnh sửa thông tin cá nhân, vai trò, hoặc trạng thái tài khoản.
Xóa Người Dùng:
Quản trị viên có thể xóa người dùng khỏi hệ thống thông qua nút "Delete" (Xóa). Hệ thống sẽ hiển thị xác nhận trước khi thực hiện hành động này để tránh việc xóa nhầm.
4. Cách Thức Hoạt Động:
Hiển Thị Danh Sách:
Khi truy cập vào trang "Users List", hệ thống sẽ tải và hiển thị toàn bộ danh sách người dùng từ cơ sở dữ liệu. Danh sách được phân trang để dễ dàng quản lý khi số lượng người dùng lớn.
Chỉnh Sửa/Xóa Người Dùng:
Khi nhấn nút "Edit", trang chỉnh sửa thông tin người dùng sẽ được mở ra, cho phép quản trị viên thực hiện các thay đổi cần thiết. Tương tự, nút "Delete" sẽ kích hoạt hộp thoại xác nhận trước khi xóa người dùng.
Hiển thị danh sách tất cả người dùng trong hệ thống. 
## V. Trang Edit User (Chỉnh Sửa Người Dùng)
   ![image](https://github.com/user-attachments/assets/fae6d499-90d0-4125-9121-976deb63cdc2)

1. Giới Thiệu:
Trang "Edit User" cho phép quản trị viên chỉnh sửa thông tin chi tiết của một người dùng đã tồn tại trong hệ thống. Đây là công cụ quan trọng để quản trị viên cập nhật thông tin người dùng khi có sự thay đổi hoặc điều chỉnh cần thiết.

2. Mục Đích:

Mục đích của trang "Edit User" là:

Cho phép quản trị viên cập nhật thông tin cá nhân, tài khoản của người dùng.
Điều chỉnh vai trò (role) và trạng thái (active/inactive) của người dùng trong hệ thống.
Đảm bảo tính chính xác và cập nhật liên tục của dữ liệu người dùng.
3. Chức Năng:
Chỉnh Sửa Thông Tin Cá Nhân:

Quản trị viên có thể cập nhật các thông tin như: Họ tên, email, tên đăng nhập (username), ngày sinh, địa chỉ, số điện thoại.
Thay Đổi Mật Khẩu:

Nếu cần, quản trị viên có thể đặt lại mật khẩu cho người dùng bằng cách nhập mật khẩu mới. Mật khẩu sẽ được mã hóa trước khi lưu vào cơ sở dữ liệu.
Thay Đổi Vai Trò (Role):

Quản trị viên có thể thay đổi vai trò của người dùng, điều chỉnh quyền hạn của họ trong hệ thống (ví dụ: từ User thành Admin hoặc ngược lại).
Cập Nhật Hình Ảnh Hồ Sơ:

Cho phép quản trị viên thay đổi hình ảnh hồ sơ của người dùng bằng cách tải lên tệp hình ảnh mới.
Lưu Thay Đổi:

Sau khi chỉnh sửa, quản trị viên có thể lưu các thay đổi vào cơ sở dữ liệu. Hệ thống sẽ cập nhật thông tin ngay lập tức.
4. Cách Thức Hoạt Động:
Hiển Thị Thông Tin Người Dùng:

Khi truy cập vào trang "Edit User", thông tin hiện tại của người dùng sẽ được tải và hiển thị trong các trường nhập liệu. Quản trị viên có thể dễ dàng chỉnh sửa các thông tin này.
Thay Đổi & Lưu Thông Tin:

Sau khi quản trị viên hoàn thành việc chỉnh sửa, họ có thể nhấn nút "Save" để lưu lại các thay đổi. Nếu có lỗi hoặc trùng lặp dữ liệu (ví dụ: email hoặc tên đăng nhập đã tồn tại), hệ thống sẽ hiển thị thông báo lỗi.
Kiểm Tra Dữ Liệu Đầu Vào:

Hệ thống sẽ kiểm tra tính hợp lệ của các dữ liệu nhập vào như email, số điện thoại, và mật khẩu. Nếu dữ liệu không hợp lệ, trang sẽ hiển thị thông báo lỗi chi tiết để quản trị viên có thể điều chỉnh.
## VI Trang Delete User (Xóa Người Dùng)
 Giới Thiệu:
Trang "Delete User" cho phép quản trị viên thực hiện thao tác xóa người dùng ra khỏi hệ thống. Đây là một chức năng quan trọng trong việc quản lý người dùng, giúp loại bỏ các tài khoản không còn sử dụng hoặc không còn phù hợp với quy định của hệ thống.

2. Mục Đích:
Mục đích của trang "Delete User" là:

Xóa bỏ tài khoản người dùng không cần thiết, hoặc vi phạm quy định.
Duy trì sự gọn gàng và bảo mật của hệ thống quản lý người dùng.
Đảm bảo chỉ những người dùng hợp lệ và cần thiết mới được giữ lại trong cơ sở dữ liệu.
3. Chức Năng:
Hiển Thị Thông Tin Người Dùng Trước Khi Xóa:

Trước khi xóa, hệ thống sẽ hiển thị thông tin chi tiết của người dùng như: Họ tên, email, vai trò (role), và trạng thái (active/inactive).
Xác Nhận Xóa:

Để tránh các thao tác xóa nhầm, trang sẽ yêu cầu quản trị viên xác nhận hành động xóa bằng cách hiển thị một hộp thoại hoặc yêu cầu nhấn nút xác nhận trước khi tiến hành xóa tài khoản.
Xóa Người Dùng:

Sau khi xác nhận, hệ thống sẽ xóa tài khoản người dùng khỏi cơ sở dữ liệu. Các dữ liệu liên quan đến người dùng này cũng có thể được xóa hoặc gắn cờ (flag) tùy thuộc vào yêu cầu cụ thể của hệ thống.
Thông Báo Kết Quả:
## Trang "Create User" (Tạo Người Dùng Mới)
Mô Tả Trang "Create User" (Tạo Người Dùng Mới)
1. Mục Đích:

Trang "Create User" được thiết kế để cho phép người quản trị (Admin) hoặc những người có quyền hạn tạo mới một người dùng trong hệ thống. Đây là bước đầu tiên trong việc quản lý người dùng, cho phép thêm thông tin chi tiết về người dùng mới, bao gồm thông tin cá nhân và các thiết lập tài khoản.

2. Các Thành Phần Chính:

Form Nhập Thông Tin:

Fullname (Họ và Tên): Trường bắt buộc, nơi người dùng nhập tên đầy đủ của người dùng mới.
Username (Tên Đăng Nhập): Trường bắt buộc, định danh duy nhất dùng để đăng nhập vào hệ thống.
Email: Trường bắt buộc, dùng để liên lạc và có thể dùng để phục hồi mật khẩu.
Confirm Password (Xác Nhận Mật Khẩu): Trường bắt buộc, dùng để xác nhận mật khẩu đã nhập.
Gender (Giới Tính): Tùy chọn, dùng để xác định giới tính của người dùng.
Date Of Birth (Ngày Sinh): Tùy chọn, ngày sinh của người dùng.
Address (Địa Chỉ): Tùy chọn, địa chỉ nơi ở của người dùng.
Phone (Số Điện Thoại): Tùy chọn, số điện thoại liên lạc.
Role (Vai Trò): Trường bắt buộc, cho phép chọn vai trò của người dùng (ví dụ: Admin, User). Vai trò sẽ quyết định quyền hạn của người dùng trong hệ thống.
Profile Image (Ảnh Đại Diện): Tùy chọn, người dùng có thể tải lên một hình ảnh để làm ảnh đại diện.
Nút Hành Động:

Create (Tạo): Nút để xác nhận và tạo người dùng mới với các thông tin đã nhập.
Cancel (Hủy): Nút để hủy bỏ quá trình tạo người dùng và quay lại trang trước.
3. Quy Trình Hoạt Động:

Nhập Thông Tin: Người quản trị hoặc người dùng có quyền hạn điền đầy đủ thông tin vào các trường yêu cầu trong form.

Kiểm Tra Tính Hợp Lệ: Trước khi lưu thông tin, hệ thống sẽ kiểm tra tính hợp lệ của dữ liệu, bao gồm kiểm tra xem Username hoặc Email đã tồn tại trong hệ thống chưa và mật khẩu có đạt tiêu chuẩn bảo mật hay không.

Mã Hóa Mật Khẩu: Trước khi lưu vào cơ sở dữ liệu, mật khẩu sẽ được mã hóa bằng một thuật toán bảo mật để bảo vệ thông tin nhạy cảm của người dùng.

Lưu Dữ Liệu: Nếu tất cả các thông tin đều hợp lệ, hệ thống sẽ lưu thông tin người dùng mới vào cơ sở dữ liệu.

Thông Báo Kết Quả: Sau khi hoàn tất, người quản trị sẽ nhận được thông báo về việc tạo người dùng thành công. Nếu có lỗi xảy ra, hệ thống sẽ hiển thị thông báo lỗi cụ thể để người dùng có thể sửa chữa.

4. Phân Quyền:

Admin: Có quyền truy cập vào trang "Create User" để tạo người dùng mới.
User Thông Thường: Không có quyền truy cập vào trang này.

Sau khi xóa thành công, hệ thống sẽ thông báo kết quả cho quản trị viên và điều hướng họ trở lại danh sách người dùng hoặc trang quản lý chính.
## Phân Quyền Sử Dụng Trang Trong Hệ Thống User Management
1. Giới Thiệu:

Phân quyền là một phần quan trọng trong hệ thống quản lý người dùng (User Management). Nó giúp đảm bảo rằng chỉ những người dùng có quyền hạn phù hợp mới có thể truy cập và thực hiện các chức năng trên từng trang cụ thể trong hệ thống. Điều này không chỉ giúp bảo mật dữ liệu mà còn đảm bảo tính toàn vẹn và đúng đắn của các hoạt động trong hệ thống.

2. Các Cấp Độ Quyền Hạn:

Thông thường, hệ thống sẽ chia quyền hạn theo các vai trò (roles) khác nhau. Ví dụ:

Admin (Quản Trị Viên):

Có quyền truy cập và quản lý tất cả các trang trong hệ thống, bao gồm: thêm, sửa, xóa người dùng; thay đổi phân quyền; và truy cập các báo cáo hệ thống.
User (Người Dùng Thông Thường):
![image](https://github.com/user-attachments/assets/92909020-5130-4831-ad60-068210d6094a)


Chỉ có quyền truy cập và chỉnh sửa thông tin cá nhân của chính mình. Người dùng thông thường không thể truy cập vào các trang quản lý hoặc thực hiện các hành động có thể ảnh hưởng đến người dùng khác.














































