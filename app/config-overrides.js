const {alias} = require('react-app-rewire-alias')

module.exports = function override(config) {
  alias({
    '@components': 'src/components',
    '@containers' : 'src/containers',
    '@services' : 'src/services',
    '@pages' : 'src/pages',
    '@utils' : 'src/utils'
  })(config)

  return config
}