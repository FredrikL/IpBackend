require 'net/http'

@name = "HOSTNAME"
@user = "USERNAME"
@pass = "PASSWORD"
@host = "IPBACKEND-HOSTNAME"

def post
  req = Net::HTTP::Post.new("/", initheader = {'Content-Type' => 'application/json'})
  req.basic_auth @user, @pass
  req.body = "{'Name':'#{@name}'}"
  response = Net::HTTP.new(@host, 80).start{|http| http.request(req)}
  puts "Response #{response.code} #{response.message}: #{response.body}"
end

post
